using Candidates.Models;
using System.Collections.Generic;

namespace Candidates.Interfaces
{
    // Interface for candidate management
    public interface ICandidateQueryService
    {
        /// <summary>
        /// Retrieves a list of all candidates.
        /// </summary>
        IEnumerable<CandidateViewModel> GetAllCandidates();

        /// <summary>
        /// Retrieves a candidate by their ID.
        /// </summary>
        /// <param name="candidateId">The ID of the candidate to retrieve.</param>
        CandidateViewModel GetCandidateById(int candidateId);
    }
}
