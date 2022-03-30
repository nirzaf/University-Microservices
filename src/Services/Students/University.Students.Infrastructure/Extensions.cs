using BuildingBlocks;
using BuildingBlocks.CAP;
using BuildingBlocks.Exception;
using BuildingBlocks.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using University.Students.Application;
using University.Students.Application.Services;
using University.Students.Infrastructure.EfCore;
using University.Students.Infrastructure.Services;

namespace University.Students.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        var configuration = services.BuildServiceProvider().GetService<IConfiguration>();
        var connectionString = configuration!.GetSection("ConnectionString").Value;

        var outboxOptions = services.GetOptions<Options.OutboxOptions>("Outbox");
        services.AddSingleton(outboxOptions);

        services.AddErrorHandler<ExceptionToResponseMapper>();
        services.AddTransient<IExceptionToMessageMapper, ExceptionToMessageMapper>();

        services.AddDbContext<StudentDbContext>(options => options.UseSqlServer(connectionString));

        services.AddTransient<IStudentDbContext>(provider => provider.GetService<StudentDbContext>());

        services.AddDbContext<StudentDbContext>();

        services.AddTransient<IMessageBroker, MessageBroker>();
        services.AddTransient<IEventMapper, EventMapper>();
        services.AddTransient<IEventProcessor, EventProcessor>();

        services.AddCustomCap<StudentDbContext>();

        return services;
    }

    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
    {
        app.UseErrorHandler();
        return app;
    }
}