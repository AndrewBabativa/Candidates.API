using Candidates.Api.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Candidates.Api.Services.Interfaces
{
    // Interface for candidate management
    public interface ICandidateQueryService
    {
        /// <summary>
        /// Retrieves a list of all candidates.
        /// </summary>
        Task<IEnumerable<CandidateViewModel>> GetCandidates();

        /// <summary>
        /// Retrieves a candidate by their ID.
        /// </summary>
        /// <param name="candidateId">The ID of the candidate to retrieve.</param>
        Task<CandidateViewModel> GetCandidateById(int id);
    }
}
