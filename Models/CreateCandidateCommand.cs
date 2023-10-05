using System;
using System.Collections.Generic;

namespace Candidates.Models
{

    public class CreateCandidateCommand
    {
        public int IdCandidate { get; }
        public string Name { get; }
        public string Surname { get; }
        public DateTime Birthday { get; }
        public string Email { get; }
        public DateTime InsertDate { get; }
        public DateTime ModifyDate { get; }
        public List<CandidateExperience> CandidateExperiences { get; }

        public CreateCandidateCommand(int idCandidate, string name, string surname, DateTime birthday, string email, DateTime insertdate, DateTime modifydate, List<CandidateExperience> candidateExperiences)
        {
            IdCandidate = idCandidate;
            Name = name;
            Surname = surname;
            Birthday = birthday;
            Email = email;
            InsertDate = insertdate;
            ModifyDate = modifydate;
            CandidateExperiences = candidateExperiences;
        }
    }
}
