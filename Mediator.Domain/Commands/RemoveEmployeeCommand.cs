using System;
using MediatR;

namespace Mediator.Domain.Commands
{
    public record RemoveEmployeeCommand(Guid Id) : IRequest<bool>;
}