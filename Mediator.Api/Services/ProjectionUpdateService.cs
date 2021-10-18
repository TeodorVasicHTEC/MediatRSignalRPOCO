using System.Threading;
using System.Threading.Tasks;
using Mediator.Domain.Services;
using MediatR;

namespace Mediator.Api.Services
{
    public class ProjectionUpdateService : IProjectionUpdateService
    {
        private readonly IMediator _mediator;

        public ProjectionUpdateService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task SendProjectionUpdate<T>(T notification, CancellationToken cancellationToken)
        {
            await _mediator.Publish(notification, cancellationToken);
        }
    }
}