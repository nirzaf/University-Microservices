using BuildingBlocks.Persistence;
using DotNetCore.CAP;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using University.Identity.Application;
using University.Identity.Infrastructure;
using University.Identity.Infrastructure.Data;

namespace Identity.Api;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers().AddNewtonsoftJson();

        services.AddDbContext<IdentityContext>(option =>
        {
            option.UseSqlServer(Configuration.GetConnectionString("IdentityConnection"));
        });

        services.AddScoped<IDataSeeder, IdentityDataSeeder>();

        services.AddFluentValidation(x => { x.RegisterValidatorsFromAssembly(typeof(Startup).Assembly); });
        services.AddApplication()
            .AddInfrastructure();

        // For Testing Subscriber
        services.Scan(s =>
            s.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                .AddClasses(c => c.AssignableTo(typeof(ICapSubscribe)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo {Title = "University.Identity.Api", Version = "v1"});
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "University.Identity.Api v1"));
        }

        app.UseInfrastructure();
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseIdentityServer();
        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}