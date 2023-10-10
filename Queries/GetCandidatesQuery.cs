using System.Collections.Generic;
using Candidates.Api.ViewModels;
using MediatR;

namespace Candidates.Api.Queries
{

    public class GetCandidatesQuery : IRequest<List<CandidateViewModel>>
    {

    }
}
