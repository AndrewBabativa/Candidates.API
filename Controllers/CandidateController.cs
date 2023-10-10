using Microsoft.AspNetCore.Mvc;
using System;
using Swashbuckle.AspNetCore.Annotations;
using Candidates.Api.ViewModels;
using Candidates.Api.Commands;
using Candidates.Models;
using Candidates.Api.Services.Interfaces;

namespace Candidates.Api.Controllers
{
    [Route("api/candidates")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateCommandService _candidateCommandService;
        private readonly ICandidateQueryService _candidateQueryService;

        public CandidateController(ICandidateCommandService candidateCommandService, ICandidateQueryService candidateQueryService)
        {
            _candidateCommandService = candidateCommandService ?? throw new ArgumentNullException(nameof(candidateCommandService));
            _candidateQueryService = candidateQueryService ?? throw new ArgumentNullException(nameof(candidateQueryService));
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new candidate")]
        [SwaggerResponse(201, "Candidate created successfully", typeof(CandidateViewModel))]
        [SwaggerResponse(400, "Invalid candidate object")]
        public IActionResult CreateCandidate([FromBody] CreateCandidateCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid candidate object");
            }

            var createdCandidateId = _candidateCommandService.CreateCandidate(command);

            return NoContent();
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Update an existing candidate")]
        [SwaggerResponse(204, "Candidate updated successfully")]
        [SwaggerResponse(400, "Invalid candidate object")]
        [SwaggerResponse(404, "Candidate not found")]
        public IActionResult UpdateCandidate([FromBody] UpdateCandidateCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid candidate object");
            }

            var existingCandidate = _candidateQueryService.GetCandidateById(command.IdCandidate);

            if (existingCandidate == null)
            {
                return NotFound("Candidate not found");
            }

            _candidateCommandService.UpdateCandidate(command);

            return NoContent();
        }

        [HttpDelete]
        [SwaggerOperation(Summary = "Delete a candidate")]
        [SwaggerResponse(204, "Candidate deleted successfully")]
        [SwaggerResponse(404, "Candidate not found")]
        public IActionResult DeleteCandidate([FromBody] DeleteCandidateCommand command)
        {
            var candidate = _candidateQueryService.GetCandidateById(command.IdCandidate);

            if (candidate == null)
            {
                return NotFound("Candidate not found");
            }

            _candidateCommandService.DeleteCandidate(command);

            return NoContent();
        }
    }
}
