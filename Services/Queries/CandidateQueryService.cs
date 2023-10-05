using Candidates.Infrastructure;
using Candidates.Interfaces;
using Candidates.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Candidates.Services.Queries
{
    public class CandidateQueryService : ICandidateQueryService
    {
        private readonly CandidatesContext _context;

        public CandidateQueryService(CandidatesContext context)
        {
            _context = context;
        }

        public IEnumerable<CandidateViewModel> GetAllCandidates()
        {
            var candidates = _context.Candidates
                .Include(c => c.CandidateExperiences) 
                .Select(c => new CandidateViewModel
                {
                    IdCandidate = c.IdCandidate,
                    Name = c.Name,
                    Surname = c.Surname,
                    Birthday = c.Birthday,
                    Email = c.Email,
                    InsertDate = c.InsertDate,
                    ModifyDate = c.ModifyDate,
                    CandidateExperiences = c.CandidateExperiences
                        .Select(ce => new CandidateExperienceViewModel
                        {
                            IdCandidateExperience = ce.IdCandidateExperience,
                            Company = ce.Company,
                            Job = ce.Job,
                            Description = ce.Description,
                            Salary = ce.Salary,
                            BeginDate = ce.BeginDate,
                            EndDate = ce.EndDate,
                            InsertDate = ce.InsertDate,
                            ModifyDate = ce.ModifyDate,
                            IdCandidate = ce.IdCandidate
                        }).ToList()
                }).ToList(); 

            return candidates;
        }

        public CandidateViewModel GetCandidateById(int candidateId)
        {
            var candidate = _context.Candidates
             .Include(c => c.CandidateExperiences)
             .FirstOrDefault(c => c.IdCandidate == candidateId);

            if (candidate == null)
            {
                return null; 
            }

            var candidateViewModel = new CandidateViewModel
            {
                IdCandidate = candidate.IdCandidate,
                Name = candidate.Name,
                Surname = candidate.Surname,
                Birthday = candidate.Birthday,
                Email = candidate.Email,
                InsertDate = candidate.InsertDate,
                ModifyDate = candidate.ModifyDate,
                CandidateExperiences = candidate.CandidateExperiences
                    .Select(ce => new CandidateExperienceViewModel
                    {
                        IdCandidateExperience = ce.IdCandidateExperience,
                        Company = ce.Company,
                        Job = ce.Job,
                        Description = ce.Description,
                        Salary = ce.Salary,
                        BeginDate = ce.BeginDate,
                        EndDate = ce.EndDate,
                        InsertDate = ce.InsertDate,
                        ModifyDate = ce.ModifyDate,
                        IdCandidate = ce.IdCandidate
                    })
                    .ToList()
            };

            return candidateViewModel;
        }
    }
}
