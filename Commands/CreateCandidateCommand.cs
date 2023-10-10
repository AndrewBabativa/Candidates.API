using System;
using System.Collections.Generic;
using Candidates.Api.ViewModels;
using Candidates.Models;
using MediatR;

namespace Candidates.Api.Commands
{
    public class CreateCandidateCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public IEnumerable<CandidateExperience> CandidateExperiences { get; set; }
    }
}
