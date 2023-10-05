using Candidates.Models;

namespace Candidates.Interfaces
{
    // Interface for candidate management
    public interface ICandidateCommandService
    {

        /// <summary>
        /// Adds a new candidate.
        /// </summary>
        /// <param name="candidate">The candidate to add.</param>
        int AddCandidate(CreateCandidateCommand candidate);

        /// <summary>
        /// Updates an existing candidate.
        /// </summary>
        /// <param name="candidate">The candidate with updated information.</param>
        void UpdateCandidate(int candidateId, CreateCandidateCommand candidate);

        /// <summary>
        /// Deletes a candidate by their ID.
        /// </summary>
        /// <param name="candidateId">The ID of the candidate to delete.</param>
        void DeleteCandidate(int candidateId);
    }
}
