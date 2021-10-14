using System;
using MediatR;

namespace Mediator.Domain.Notifications
{
    public record EmployeeAddedEvent(string Employee, Guid EmployeeId) : INotification;
}