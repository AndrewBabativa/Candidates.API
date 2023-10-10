using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Candidates.Api.ViewModels;
using Candidates.Api.Queries;
using MediatR;
using Candidates.Models;
using DocumentFormat.OpenXml.InkML;
using Candidates.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Routing.Matching;
using System.Linq;
using Candidates.Api.Services.Interfaces;

public class CandidateQueryService : ICandidateQueryService
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly CandidatesContext _context;

    public CandidateQueryService(IMediator mediator, IMapper mapper, CandidatesContext context)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<IEnumerable<CandidateViewModel>> GetCandidates()
    {
        try
        {
            var candidates = await _context.Candidates
             .Include(c => c.CandidateExperiences) 
             .ToListAsync();

            return CandidatesToViewModel(candidates);
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error al obtener la lista de candidatos.", ex);
        }
    }

    public async Task<CandidateViewModel> GetCandidateById(int id)
    {
        try
        {
            var candidates = await _context.Candidates
                .Include(c => c.CandidateExperiences)
                .Where(c => c.IdCandidate == id) 
                .FirstAsync();

            return CandidateToViewModel(candidates);
        }
        catch (Exception ex)
        {
            throw new ApplicationException($"Error al obtener el candidato con ID {id}.", ex);
        }
    }

    private List<CandidateViewModel> CandidatesToViewModel(List<Candidate> candidates)
    {
        var candidateViewModels = new List<CandidateViewModel>();

        foreach (var candidate in candidates)
        {
            var candidateViewModel = new CandidateViewModel
            {
                IdCandidate = candidate.IdCandidate,
                Name = candidate.Name,
                Surname = candidate.Surname,
                Birthday = candidate.Birthday,
                Email = candidate.Email,
                InsertDate = candidate.InsertDate,
                ModifyDate = candidate.ModifyDate,
                CandidateExperiences = candidate.CandidateExperiences.Select(experience => new CandidateExperienceViewModel
                {
                    IdCandidateExperience = experience.IdCandidateExperience,
                    Company = experience.Company,
                    Job = experience.Job,
                    Description = experience.Description,
                    Salary = experience.Salary,
                    BeginDate = experience.BeginDate,
                    EndDate = experience.EndDate,
                    InsertDate = experience.InsertDate,
                    ModifyDate = experience.ModifyDate,
                    IdCandidate = experience.IdCandidate
                }).ToList()
            };

            candidateViewModels.Add(candidateViewModel);
        }

        return candidateViewModels;
    }

    private CandidateViewModel CandidateToViewModel(Candidate candidate)
    {
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
            CandidateExperiences = candidate.CandidateExperiences.Select(experience => new CandidateExperienceViewModel
            {
                IdCandidateExperience = experience.IdCandidateExperience,
                Company = experience.Company,
                Job = experience.Job,
                Description = experience.Description,
                Salary = experience.Salary,
                BeginDate = experience.BeginDate,
                EndDate = experience.EndDate,
                InsertDate = experience.InsertDate,
                ModifyDate = experience.ModifyDate,
                IdCandidate = experience.IdCandidate
            }).ToList()
        };

        return candidateViewModel;
    }

}

