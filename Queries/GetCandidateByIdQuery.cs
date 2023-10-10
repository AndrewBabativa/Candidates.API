using Candidates.Api.ViewModels;
using MediatR;

namespace Candidates.Api.Queries
{

    public class GetCandidateByIdQuery : IRequest<CandidateViewModel>
    {
        public int IdCandidate { get; set; }
    }
}
