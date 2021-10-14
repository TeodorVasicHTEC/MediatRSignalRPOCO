using System.Threading;
using System.Threading.Tasks;
using Mediator.Api.Config;
using Mediator.Domain.Notifications;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace Mediator.Api.Handlers
{
    public class EmployeeServiceNotificationsHandler : 
        INotificationHandler<EmployeeAddedEvent>,
        INotificationHandler<EmployeeRemovedEvent>
    {
        private readonly IHubContext<EmployeeServiceNotificationHub> _hubContext;

        public EmployeeServiceNotificationsHandler(IHubContext<EmployeeServiceNotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public Task Handle(EmployeeAddedEvent notification, CancellationToken cancellationToken)
        {
            return _hubContext.Clients.All.SendAsync("NewUserCreated", notification, cancellationToken);
        }

        public Task Handle(EmployeeRemovedEvent notification, CancellationToken cancellationToken)
        {
            return _hubContext.Clients.All.SendAsync("UserRemoved", notification, cancellationToken);
        }
    }
}