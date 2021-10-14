using System.Threading;
using System.Threading.Tasks;
using Mediator.Domain.Commands;
using Mediator.Domain.Data;
using Mediator.Domain.Notifications;
using MediatR;

namespace Mediator.Domain.Handlers
{
    public class RemoveEmployeeHandler : IRequestHandler<RemoveEmployeeCommand, bool>
    {
        private readonly IDataAccess _dataAccess;
        private readonly IMediator _mediator;

        public RemoveEmployeeHandler(IDataAccess dataAccess, IMediator mediator)
        {
            _dataAccess = dataAccess;
            _mediator = mediator;
        }

        public async Task<bool> Handle(RemoveEmployeeCommand request, CancellationToken cancellationToken)
        {
            await _mediator.Publish(new EmployeeRemovedEvent(request.Id), cancellationToken);
            return _dataAccess.RemoveEmployee(request.Id);
        }
    }
}