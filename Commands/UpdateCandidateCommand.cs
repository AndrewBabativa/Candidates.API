using System;
using System.Collections.Generic;
using Candidates.Models;
using MediatR;

namespace Candidates.Api.Commands
{

    public class UpdateCandidateCommand : IRequest<int>
    {
        public int IdCandidate { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public List<CandidateExperience> CandidateExperiences { get; set; }
    }
}
