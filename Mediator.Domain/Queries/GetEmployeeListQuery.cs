using System.Collections.Generic;
using Mediator.Domain.Models;
using MediatR;

namespace Mediator.Domain.Queries
{
    public record GetEmployeeListQuery() : IRequest<List<Employee>>;
}