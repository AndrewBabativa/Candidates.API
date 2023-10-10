using System.Collections.Generic;
using System.Linq;
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
    public class GetCandidatesQueryHandler : IRequestHandler<GetCandidatesQuery, List<CandidateViewModel>>
    {
        private readonly CandidatesContext _context;
        private readonly IMapper _mapper; 

        public GetCandidatesQueryHandler(CandidatesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CandidateViewModel>> Handle(GetCandidatesQuery request, CancellationToken cancellationToken)
        {
            var candidates = await _context.Candidates.ToListAsync();
            var candidateViewModels = _mapper.Map<List<Candidate>, List<CandidateViewModel>>(candidates);

            return candidateViewModels;
        }
    }
}
