using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Mediator.Domain.Data;
using Mediator.Domain.Models;
using Mediator.Domain.Queries;
using MediatR;

namespace Mediator.Domain.Handlers
{
    public class GetEmployeeListHandler : IRequestHandler<GetEmployeeListQuery, List<Employee>>
    {
        private readonly IDataAccess _dataAccess;
        public GetEmployeeListHandler(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public Task<List<Employee>> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_dataAccess.GetEmployees());
        }
    }
}