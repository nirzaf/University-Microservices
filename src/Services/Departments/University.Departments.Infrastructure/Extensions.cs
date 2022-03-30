using BuildingBlocks;
using BuildingBlocks.CAP;
using BuildingBlocks.Exception;
using BuildingBlocks.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using University.Departments.Application;
using University.Departments.Application.Services;
using University.Departments.Infrastructure.EfCore;
using University.Departments.Infrastructure.Services;

namespace University.Departments.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        var configuration = services.BuildServiceProvider().GetService<IConfiguration>();
        var connectionString = configuration!.GetSection("connectionString").Value;

        services.AddErrorHandler<ExceptionToResponseMapper>();
        services.AddTransient<IExceptionToMessageMapper, ExceptionToMessageMapper>();

        services.AddDbContext<DepartmentDbContext>(options =>
            options.UseSqlServer(connectionString));


        var outboxOptions = services.GetOptions<Options.OutboxOptions>("outbox");
        services.AddSingleton(outboxOptions);

        services.AddTransient<IDepartmentDbContext>(provider => provider.GetService<DepartmentDbContext>());

        services.AddDbContext<DepartmentDbContext>();

        services.AddTransient<IMessageBroker, MessageBroker>();
        services.AddTransient<IEventMapper, EventMapper>();
        services.AddTransient<IEventProcessor, EventProcessor>();

        services.AddCustomCap<DepartmentDbContext>();

        return services;
    }

    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
    {
        app.UseErrorHandler();
        return app;
    }
}