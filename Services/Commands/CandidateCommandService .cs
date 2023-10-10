using System;
using System.Linq;
using System.Threading.Tasks;
using Candidates.Models;
using Candidates.Api.Commands;
using Microsoft.EntityFrameworkCore;
using Candidates.Infrastructure;
using Candidates.Api.Services.Interfaces;

public class CandidateCommandService : ICandidateCommandService
{
    private readonly CandidatesContext _context;

    public CandidateCommandService(CandidatesContext context)
    {
        _context = context;
    }

    public async Task<int> CreateCandidate(CreateCandidateCommand command)
    {
        var candidate = new Candidate
        {
            Name = command.Name,
            Surname = command.Surname,
            Birthday = command.Birthday,
            Email = command.Email,
            InsertDate = DateTime.UtcNow, 
            ModifyDate = DateTime.UtcNow,
            CandidateExperiences = command.CandidateExperiences
        };

        _context.Add(candidate);

        if (command.CandidateExperiences != null && command.CandidateExperiences.Any())
        {
            foreach (var experience in command.CandidateExperiences)
            {
                experience.IdCandidate = candidate.IdCandidate;
                _context.CandidateExperiences.Add(experience);
            }
        }

        await _context.SaveChangesAsync();

        return candidate.IdCandidate;
    }

    public async Task<int> UpdateCandidate(UpdateCandidateCommand command)
    {
        var existingCandidate = await _context.Candidates
            .Include(c => c.CandidateExperiences)
            .FirstOrDefaultAsync(c => c.IdCandidate == command.IdCandidate);

        if (existingCandidate != null)
        {
            existingCandidate.Name = command.Name;
            existingCandidate.Surname = command.Surname;
            existingCandidate.Birthday = command.Birthday;
            existingCandidate.Email = command.Email;
            existingCandidate.ModifyDate = DateTime.UtcNow;
            existingCandidate.CandidateExperiences = command.CandidateExperiences;
            await _context.SaveChangesAsync();
        }

        return existingCandidate?.IdCandidate ?? 0;
    }

    public async Task<int> DeleteCandidate(DeleteCandidateCommand command)
    {
        var candidate = await _context.Candidates
            .Include(c => c.CandidateExperiences)
            .FirstOrDefaultAsync(c => c.IdCandidate == command.IdCandidate);

        if (candidate != null)
        {
            _context.RemoveRange(candidate.CandidateExperiences);
            _context.Remove(candidate);
            await _context.SaveChangesAsync();
        }

        return candidate?.IdCandidate ?? 0;
    }
}
