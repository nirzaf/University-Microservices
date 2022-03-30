using System;
using BuildingBlocks.CQRS.Queries.Dispatchers;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.CQRS.Queries;

public static class Extensions
{
    public static IServiceCollection AddQueryHandlers(this IServiceCollection service)
    {
        service.Scan(s =>
            s.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());

        return service;
    }

    public static IServiceCollection AddInMemoryQueryDispatcher(this IServiceCollection service)
    {
        service.AddSingleton<IQueryDispatcher, QueryDispatcher>();
        return service;
    }
}