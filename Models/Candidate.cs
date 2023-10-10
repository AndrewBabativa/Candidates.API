using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;
using Candidates.Api.ViewModels;

namespace Candidates.Models
{
    public class Candidate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCandidate { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        public string Surname { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [Required]
        [StringLength(250)]
        public string Email { get; set; }

        public DateTime InsertDate { get; set; }
        public DateTime ModifyDate { get; set; }

        public IEnumerable<CandidateExperience> CandidateExperiences { get; set; }

    }
}
