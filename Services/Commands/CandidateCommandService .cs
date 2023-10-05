using Candidates.Infrastructure;
using Candidates.Interfaces;
using Candidates.Models;
using System.Collections.Generic;
using System;
using System.Linq;

public class CandidateCommandService : ICandidateCommandService
{
    private readonly CandidatesContext _context;

    public CandidateCommandService(CandidatesContext context)
    {
        _context = context;
    }

    public int AddCandidate(CreateCandidateCommand command)
    {
        var candidate = new Candidate
        {
            Name = command.Name,
            Surname = command.Surname,
            Birthday = command.Birthday,
            Email = command.Email,
            InsertDate = command.InsertDate,
            ModifyDate = command.ModifyDate,
            CandidateExperiences = command.CandidateExperiences
        };

        _context.Add(candidate);

        int candidateId = candidate.IdCandidate;

        if (command.CandidateExperiences != null && command.CandidateExperiences.Any())
        {
            foreach (var experience in command.CandidateExperiences)
            {
                experience.IdCandidate = candidateId;
                _context.CandidateExperiences.Add(experience);
            }

            _context.SaveChanges();
        }

        return candidate.IdCandidate;
    }


    public void UpdateCandidate(int candidateId, CreateCandidateCommand command)
    {
        var existingCandidate = _context.Candidates.Find(candidateId);

        if (existingCandidate != null)
        {
            existingCandidate.Name = command.Name;
            existingCandidate.Surname = command.Surname;
            existingCandidate.Birthday = command.Birthday;
            existingCandidate.Email = command.Email;
            existingCandidate.InsertDate = command.InsertDate;
            existingCandidate.ModifyDate = command.ModifyDate;

            var currentExperiences = _context.CandidateExperiences.Where(e => e.IdCandidate == candidateId).ToList();

            var updatedExperiences = new List<CandidateExperience>();
            var deletedExperiences = new List<CandidateExperience>();

            foreach (var newExperience in command.CandidateExperiences)
            {
                var existingExperience = currentExperiences.FirstOrDefault(e => e.IdCandidateExperience == newExperience.IdCandidateExperience);

                if (existingExperience != null)
                {
                    existingExperience.Company = newExperience.Company;
                    existingExperience.Job = newExperience.Job;
                    existingExperience.Description = newExperience.Description;
                    existingExperience.Salary = newExperience.Salary;
                    existingExperience.BeginDate = newExperience.BeginDate;
                    existingExperience.EndDate = newExperience.EndDate;
                    existingExperience.ModifyDate = DateTime.UtcNow;

                    updatedExperiences.Add(existingExperience);
                }
                else
                {
                    newExperience.IdCandidate = candidateId; 
                    _context.Add(newExperience);
                }
            }

            foreach (var currentExperience in currentExperiences)
            {
                if (!updatedExperiences.Contains(currentExperience))
                {
                    deletedExperiences.Add(currentExperience);
                }
            }

            _context.RemoveRange(deletedExperiences);

            _context.SaveChanges();
        }
    }

    public void DeleteCandidate(int candidateId)
    {
        var candidate = _context.Candidates.Find(candidateId);

        if (candidate != null)
        {
            var candidateExperiences = _context.CandidateExperiences.Where(ce => ce.IdCandidate == candidateId);
            _context.CandidateExperiences.RemoveRange(candidateExperiences);

            _context.Candidates.Remove(candidate);

            _context.SaveChanges();
        }
    }


}
