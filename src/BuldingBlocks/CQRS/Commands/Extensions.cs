using System;
using BuildingBlocks.CQRS.Commands.Dispatchers;
using BuildingBlocks.Types;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.CQRS.Commands;

public static class Extensions
{
    public static IServiceCollection AddCommandHandlers(this IServiceCollection service)
    {
        service.Scan(s =>
            s.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>))
                    .WithoutAttribute(typeof(DecoratorAttribute)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());

        return service;
    }

    public static IServiceCollection AddInMemoryCommandDispatcher(this IServiceCollection service)
    {
        service.AddSingleton<ICommandDispatcher, CommandDispatcher>();
        return service;
    }
}