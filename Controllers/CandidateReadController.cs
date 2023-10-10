using Candidates.Api.Services.Interfaces;
using Candidates.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<IEnumerable<CandidateViewModel>> GetAllCandidates()
        {
            var candidates = await _candidateQueryService.GetCandidates();
            return candidates.ToList();
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get a candidate by ID",
            Description = "Retrieves a candidate by their unique ID."
        )]
        [SwaggerResponse(200, "The candidate was found.", typeof(CandidateViewModel))]
        [SwaggerResponse(404, "The candidate with the specified ID was not found.")]
        public async Task<ActionResult<CandidateViewModel>> GetCandidateById(int id)
        {
            var candidate = await _candidateQueryService.GetCandidateById(id);

            if (candidate == null)
            {
                return NotFound();
            }

            return candidate;
        }
    }
}
