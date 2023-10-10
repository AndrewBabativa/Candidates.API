using System;
using System.Collections.Generic;

namespace Candidates.Api.ViewModels
{

    public class CandidateViewModel
    {
        public int IdCandidate { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public IEnumerable<CandidateExperienceViewModel> CandidateExperiences { get; set; }
    }
}
