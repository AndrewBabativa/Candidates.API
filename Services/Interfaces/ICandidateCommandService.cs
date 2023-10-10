using System.Threading.Tasks;
using Candidates.Api.Commands;

namespace Candidates.Api.Services.Interfaces
{
    public interface ICandidateCommandService
    {
        Task<int> CreateCandidate(CreateCandidateCommand command);
        Task<int> UpdateCandidate(UpdateCandidateCommand command);
        Task<int> DeleteCandidate(DeleteCandidateCommand command);
    }
}