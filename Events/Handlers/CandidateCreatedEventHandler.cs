using Candidates.Interfaces;
using Candidates.Events.Events;
using Candidates.Hubs;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using System.Threading;
using System.Threading.Tasks;

namespace Candidates.Events.Handlers
{
    public class CandidateCreatedEventHandler : INotificationHandler<CandidateCreatedEvent>
    {
        private readonly ICandidateQueryService _queryService;
        private readonly IHubContext<NotificationHub> _hubContext;

        public CandidateCreatedEventHandler(ICandidateQueryService queryService, IHubContext<NotificationHub> hubContext)
        {
            _queryService = queryService;
            _hubContext = hubContext;
        }

        public async Task Handle(CandidateCreatedEvent notification, CancellationToken cancellationToken)
        {
            var newCandidate = _queryService.GetCandidateById(notification.CandidateId);
            await _hubContext.Clients.All.SendAsync("ReceiveCandidateCreated", newCandidate);
        }
    }

}
