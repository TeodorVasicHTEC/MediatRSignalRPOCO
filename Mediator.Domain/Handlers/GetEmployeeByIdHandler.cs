using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Mediator.Domain.Data;
using Mediator.Domain.Models;
using Mediator.Domain.Queries;
using MediatR;

namespace Mediator.Domain.Handlers
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, Employee>
    {
        private readonly IDataAccess _dataAccess;
        public GetEmployeeByIdHandler(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public Task<Employee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employees = _dataAccess.GetEmployees();
            var employee = employees.Single(e => e.Id == request.userId);
            return Task.FromResult(employee);
        }
    }
}