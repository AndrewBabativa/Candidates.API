using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Candidates.Api.Queries;
using Candidates.Api.ViewModels;
using Candidates.Infrastructure;
using Candidates.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CandidatesApp.Queries
{
    public class GetCandidateByIdQueryHandler : IRequestHandler<GetCandidateByIdQuery, CandidateViewModel>
    {
        private readonly CandidatesContext _context;
        private readonly IMapper _mapper;

        public GetCandidateByIdQueryHandler(CandidatesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CandidateViewModel> Handle(GetCandidateByIdQuery request, CancellationToken cancellationToken)
        {
            var candidate = await _context.Candidates.FirstOrDefaultAsync(c => c.IdCandidate == request.IdCandidate);

            if (candidate == null)
            {
                return null;
            }

            var candidateViewModel = _mapper.Map<Candidate, CandidateViewModel>(candidate);

            return candidateViewModel;
        }
    }
}
