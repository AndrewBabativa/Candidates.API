using System.Threading;
using System.Threading.Tasks;
using Candidates.Api.Commands;
using Candidates.Api.Services.Interfaces;
using MediatR;

namespace CandidatesApp.Queries
{
    public class CreateCandidateCommandHandler : IRequestHandler<CreateCandidateCommand, int>
    {
        private readonly ICandidateCommandService _candidateCommandService;

        public CreateCandidateCommandHandler(ICandidateCommandService candidateCommandService)
        {
            _candidateCommandService = candidateCommandService;
        }

        public async Task<int> Handle(CreateCandidateCommand request, CancellationToken cancellationToken)
        {
            var createdCandidateId = await _candidateCommandService.CreateCandidate(request);

            return createdCandidateId;
        }
    }

}
