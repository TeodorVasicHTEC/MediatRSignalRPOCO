using System.Threading;
using System.Threading.Tasks;
using Mediator.Domain.Commands;
using Mediator.Domain.Data;
using Mediator.Domain.Models;
using Mediator.Domain.Notifications;
using Mediator.Domain.Services;
using MediatR;

namespace Mediator.Domain.Handlers
{
    public class AddEmployeeHandler : IRequestHandler<AddEmployeeCommand, Employee>
    {
        private readonly IDataAccess _dataAccess;
        private readonly IProjectionUpdateService _projectionUpdateService;

        public AddEmployeeHandler(IDataAccess dataAccess, IProjectionUpdateService projectionUpdateService)
        {
            _dataAccess = dataAccess;
            _projectionUpdateService = projectionUpdateService;
        }

        public async Task<Employee> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            var newEmployee = _dataAccess.AddEmployee(request.FirstName, request.LastName);
            await _projectionUpdateService.SendProjectionUpdate(new EmployeeAddedEvent($"{newEmployee.FirstName} {newEmployee.LastName}",
                newEmployee.Id), cancellationToken);
            return newEmployee;
        }
    }
}