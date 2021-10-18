using System.Threading;
using System.Threading.Tasks;

namespace Mediator.Domain.Services
{
    public interface IProjectionUpdateService
    {
        Task SendProjectionUpdate<T>(T notification, CancellationToken cancellationToken);
    }
}