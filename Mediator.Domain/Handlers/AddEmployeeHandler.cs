using System.Threading;
using System.Threading.Tasks;
using Mediator.Domain.Commands;
using Mediator.Domain.Data;
using Mediator.Domain.Models;
using Mediator.Domain.Notifications;
using MediatR;

namespace Mediator.Domain.Handlers
{
    public class AddEmployeeHandler : IRequestHandler<AddEmployeeCommand, Employee>
    {
        private readonly IDataAccess _dataAccess;
        private readonly IMediator _mediator;

        public AddEmployeeHandler(IDataAccess dataAccess, IMediator mediator)
        {
            _dataAccess = dataAccess;
            _mediator = mediator;
        }

        public async Task<Employee> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            var newEmployee = _dataAccess.AddEmployee(request.FirstName, request.LastName);
            await _mediator.Publish(new EmployeeAddedEvent($"{newEmployee.FirstName} {newEmployee.LastName}",
                newEmployee.Id), cancellationToken);
            return newEmployee;
        }
    }
}