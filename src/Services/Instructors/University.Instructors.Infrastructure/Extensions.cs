using BuildingBlocks;
using BuildingBlocks.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using University.Instructors.Application.Services;
using University.Instructors.Infrastructure.EfCore;
using University.Instructors.Infrastructure.Services;

namespace University.Instructors.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        var configuration = services.BuildServiceProvider().GetService<IConfiguration>();
        var connectionString = configuration!.GetSection("connectionString").Value;

        services.AddDbContext<InstructorDbContext>(options =>
            options.UseSqlServer(connectionString));


        var outboxOptions = services.GetOptions<Options.OutboxOptions>("outbox");
        services.AddSingleton(outboxOptions);

        services.AddTransient(provider => provider.GetService<InstructorDbContext>());

        services.AddDbContext<InstructorDbContext>();

        services.AddTransient<IMessageBroker, MessageBroker>();
        services.AddTransient<IEventMapper, EventMapper>();
        services.AddTransient<IEventProcessor, EventProcessor>();

        services.AddCap(x =>
        {
            x.UseEntityFramework<InstructorDbContext>();

            x.UseSqlServer(connectionString);

            x.UseRabbitMQ(r =>
            {
                r.HostName = "localhost";
                r.ExchangeName = "instructors";
            });

            x.FailedRetryCount = 5;
        });

        return services;
    }

    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
    {
        return app;
    }
}