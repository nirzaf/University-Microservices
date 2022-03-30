using System.Threading.Tasks;

namespace BuildingBlocks.CQRS.Commands;

public interface ICommandDispatcher
{
    Task SendAsync<T>(T command) where T : class, ICommand;
}