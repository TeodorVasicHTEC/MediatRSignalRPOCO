using System;
using MediatR;

namespace Mediator.Domain.Notifications
{
    public record EmployeeRemovedEvent(Guid EmployeeId) : INotification;
}