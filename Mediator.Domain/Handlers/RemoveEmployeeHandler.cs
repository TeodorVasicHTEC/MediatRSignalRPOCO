using System.Threading;
using System.Threading.Tasks;
using Mediator.Domain.Commands;
using Mediator.Domain.Data;
using Mediator.Domain.Notifications;
using Mediator.Domain.Services;
using MediatR;

namespace Mediator.Domain.Handlers
{
    public class RemoveEmployeeHandler : IRequestHandler<RemoveEmployeeCommand, bool>
    {
        private readonly IDataAccess _dataAccess;
        private readonly IProjectionUpdateService _projectionUpdateService;

        public RemoveEmployeeHandler(IDataAccess dataAccess, IProjectionUpdateService projectionUpdateService)
        {
            _dataAccess = dataAccess;
            _projectionUpdateService = projectionUpdateService;
        }

        public async Task<bool> Handle(RemoveEmployeeCommand request, CancellationToken cancellationToken)
        {
            await _projectionUpdateService.SendProjectionUpdate(new EmployeeRemovedEvent(request.Id), cancellationToken);
            return _dataAccess.RemoveEmployee(request.Id);
        }
    }
}