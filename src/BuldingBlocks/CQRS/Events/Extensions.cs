using System;
using BuildingBlocks.CQRS.Events.Dispatchers;
using BuildingBlocks.Types;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.CQRS.Events;

public static class Extensions
{
    public static IServiceCollection AddEventHandlers(this IServiceCollection service)
    {
        service.Scan(s =>
            s.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                .AddClasses(c => c.AssignableTo(typeof(IEventHandler<>))
                    .WithoutAttribute(typeof(DecoratorAttribute)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());

        return service;
    }

    public static IServiceCollection AddInMemoryEventDispatcher(this IServiceCollection service)
    {
        service.AddSingleton<IEventDispatcher, EventDispatcher>();
        return service;
    }
}