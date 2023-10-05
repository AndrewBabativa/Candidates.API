using MediatR;

namespace Candidates.Events.Events
{
    public class CandidateCreatedEvent : INotification
    {
        public int CandidateId { get; }
        public string Name { get; }

        public CandidateCreatedEvent(int candidateId, string name)
        {
            CandidateId = candidateId;
            Name = name;
        }
    }
}
