using System;
using System.Collections.Generic;
using Candidates.Models;
using MediatR;

namespace Candidates.Api.Commands
{

    public class DeleteCandidateCommand : IRequest<int>
    {

        public int IdCandidate { get; set; }
    }
}
