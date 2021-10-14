using Mediator.Domain.Models;
using MediatR;

namespace Mediator.Domain.Commands
{
    public record AddEmployeeCommand(string FirstName, string LastName) : IRequest<Employee>;
}