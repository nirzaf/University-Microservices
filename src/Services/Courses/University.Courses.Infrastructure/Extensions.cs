using BuildingBlocks;
using BuildingBlocks.CAP;
using BuildingBlocks.Exception;
using BuildingBlocks.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using University.Courses.Application;
using University.Courses.Application.Services;
using University.Courses.Infrastructure.EfCore;
using University.Courses.Infrastructure.Services;

namespace University.Courses.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        var configuration = services.BuildServiceProvider().GetService<IConfiguration>();
        var connectionString = configuration!.GetSection("connectionString").Value;

        services.AddErrorHandler<ExceptionToResponseMapper>();
        services.AddTransient<IExceptionToMessageMapper, ExceptionToMessageMapper>();

        services.AddDbContext<CourseDbContext>(options =>
            options.UseSqlServer(connectionString));


        var outboxOptions = services.GetOptions<Options.OutboxOptions>("outbox");
        services.AddSingleton(outboxOptions);

        services.AddTransient<ICourseDbContext>(provider => provider.GetService<CourseDbContext>());

        services.AddTransient<IMessageBroker, MessageBroker>();
        services.AddTransient<IEventMapper, EventMapper>();
        services.AddTransient<IEventProcessor, EventProcessor>();

        services.AddCustomCap<CourseDbContext>();

        return services;
    }

    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
    {
        app.UseErrorHandler();

        return app;
    }
}