using System.Threading;
using System.Threading.Tasks;

namespace BuildingBlocks.CQRS.Commands;

public interface ICommandHandler<in TCommand> where TCommand : ICommand
{
    Task HandleAsync(TCommand command, CancellationToken token);
}