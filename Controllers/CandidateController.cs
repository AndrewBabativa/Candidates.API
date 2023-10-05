using Candidates.Interfaces;
using Candidates.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using Swashbuckle.AspNetCore.Annotations;

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

        /// <summary>
        /// Creates a new candidate.
        /// </summary>
        /// <param name="command">The candidate creation request.</param>
        /// <returns>The newly created candidate.</returns>
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

            var createdCandidate =_candidateCommandService.AddCandidate(command);

            return CreatedAtAction("GetCandidateById", new { id = createdCandidate }, createdCandidate);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update an existing candidate")]
        [SwaggerResponse(204, "Candidate updated successfully")]
        [SwaggerResponse(400, "Invalid candidate object")]
        [SwaggerResponse(404, "Candidate not found")]
        public IActionResult UpdateCandidate(int id, [FromBody] CreateCandidateCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid candidate object");
            }

            // Verificar si el candidato existe antes de intentar actualizarlo
            var existingCandidate = _candidateQueryService.GetCandidateById(id);

            if (existingCandidate == null)
            {
                return NotFound("Candidate not found");
            }

            _candidateCommandService.UpdateCandidate(id, command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a candidate")]
        [SwaggerResponse(204, "Candidate deleted successfully")]
        [SwaggerResponse(404, "Candidate not found")]
        public IActionResult DeleteCandidate(int id)
        {
            var candidate = _candidateQueryService.GetCandidateById(id);

            if (candidate == null)
            {
                return NotFound("Candidate not found");
            }

            _candidateCommandService.DeleteCandidate(id);

            return NoContent();
        }
    }
}
