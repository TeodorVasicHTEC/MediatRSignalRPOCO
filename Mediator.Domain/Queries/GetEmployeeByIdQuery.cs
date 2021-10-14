using System;
using Mediator.Domain.Models;
using MediatR;

namespace Mediator.Domain.Queries
{
    public record GetEmployeeByIdQuery(Guid userId) : IRequest<Employee>;
}