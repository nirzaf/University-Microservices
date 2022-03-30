using System.Threading.Tasks;

namespace BuildingBlocks.Types;

public interface IDomainEventHandler<in T> where T : class
{
    Task HandleAsync(T @event);
}