using System.Threading;
using System.Threading.Tasks;
using Candidates.Api.Commands;
using Candidates.Api.Services.Interfaces;
using MediatR;

namespace CandidatesApp.Queries
{
    public class UpdateCandidateCommandHandler : IRequestHandler<UpdateCandidateCommand, int>
    {
        private readonly ICandidateCommandService _candidateCommandService;

        public UpdateCandidateCommandHandler(ICandidateCommandService candidateCommandService)
        {
            _candidateCommandService = candidateCommandService;
        }

        public async Task<int> Handle(UpdateCandidateCommand request, CancellationToken cancellationToken)
        {
            var createdCandidateId = await _candidateCommandService.UpdateCandidate(request);

            return createdCandidateId;
        }
    }

}
