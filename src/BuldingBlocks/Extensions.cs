using BuildingBlocks.Exception;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks;

public static class Extensions
{
    private const string SectionName = "app";

    public static IServiceCollection AddErrorHandler<T>(this IServiceCollection services)
        where T : class, IExceptionToResponseMapper
    {
        services.AddTransient<ErrorHandlerMiddleware>();
        services.AddSingleton<IExceptionToResponseMapper, T>();

        return services;
    }

    public static IApplicationBuilder UseErrorHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ErrorHandlerMiddleware>();
    }

    public static TModel GetOptions<TModel>(this IConfiguration configuration, string sectionName)
        where TModel : new()
    {
        var model = new TModel();
        configuration.GetSection(sectionName).Bind(model);
        return model;
    }

    public static TModel GetOptions<TModel>(this IServiceCollection services, string settingsSectionName)
        where TModel : new()
    {
        using var serviceProvider = services.BuildServiceProvider();
        var configuration = serviceProvider.GetService<IConfiguration>();
        return configuration.GetOptions<TModel>(settingsSectionName);
    }
}