using System.Threading;
using System.Threading.Tasks;
using Candidates.Api.Commands;
using Candidates.Api.Services.Interfaces;
using MediatR;

namespace CandidatesApp.Queries
{
    public class DeleteCandidateCommandHandler : IRequestHandler<DeleteCandidateCommand, int>
    {
        private readonly ICandidateCommandService _candidateCommandService;

        public DeleteCandidateCommandHandler(ICandidateCommandService candidateCommandService)
        {
            _candidateCommandService = candidateCommandService;
        }

        public async Task<int> Handle(DeleteCandidateCommand request, CancellationToken cancellationToken)
        {
            var createdCandidateId = await _candidateCommandService.DeleteCandidate(request);

            return createdCandidateId;
        }
    }

}
