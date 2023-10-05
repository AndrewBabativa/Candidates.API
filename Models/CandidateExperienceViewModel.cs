using System;
using System.ComponentModel.DataAnnotations;

namespace Candidates.Models
{
    public class CandidateExperienceViewModel
    {
        public int IdCandidateExperience { get; set; }
        public string Company { get; set; }
        public string Job { get; set; }
        public string Description { get; set; }
        public decimal Salary { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public int IdCandidate { get; set; }
    }
}
