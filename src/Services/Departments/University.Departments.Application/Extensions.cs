using BuildingBlocks.CQRS.Commands;
using BuildingBlocks.CQRS.Events;
using BuildingBlocks.CQRS.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace University.Departments.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services
            .AddCommandHandlers()
            .AddEventHandlers()
            .AddInMemoryCommandDispatcher()
            .AddInMemoryEventDispatcher()
            .AddQueryHandlers()
            .AddInMemoryQueryDispatcher();
    }
}