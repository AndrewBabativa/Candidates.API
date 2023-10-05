using Candidates.Interfaces;
using Candidates.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Linq;

namespace Candidates.Api.Controllers
{
    [Route("api/candidates/read")]
    [ApiController]
    public class CandidateReadController : ControllerBase
    {
        private readonly ICandidateQueryService _candidateQueryService;

        public CandidateReadController(ICandidateQueryService candidateQueryService)
        {
            _candidateQueryService = candidateQueryService ?? throw new ArgumentNullException(nameof(candidateQueryService));
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Get all candidates",
            Description = "Retrieves a list of all candidates in the system."
        )]
        public IEnumerable<CandidateViewModel> GetAllCandidates()
        {
            var candidates = _candidateQueryService.GetAllCandidates();

            var candidateViewModels = candidates.Select(candidate => new CandidateViewModel
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
            });

            return candidateViewModels.ToList();
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get a candidate by ID",
            Description = "Retrieves a candidate by their unique ID."
        )]
        [SwaggerResponse(200, "The candidate was found.", typeof(CandidateViewModel))]
        [SwaggerResponse(404, "The candidate with the specified ID was not found.")]
        public ActionResult<CandidateViewModel> GetCandidateById(int id)
        {
            var candidate = _candidateQueryService.GetCandidateById(id);

            if (candidate == null)
            {
                return NotFound();
            }

            var viewModel = new CandidateViewModel
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

            return viewModel;
        }

    }
}
