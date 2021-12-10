using CarProject.Infrastructure;
using Microsoft.OpenApi.Models;
using CarProject.Api.Middleware.Extension;

namespace CarProject.Api;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddInfrastructure();
        services.AddCors();
        services.AddControllers();
        services.AddAutoMapper(typeof(Startup));

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "CarProject.Api", Version = "v1" });
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarProject.Api v1"));
        }
        app.UseCors(builder => builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
        app.UseStaticFiles();
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseResponseCaching();
        app.UseAuthorization();
        app.UseResponseWrapper();
        app.UseExceptionMiddeware();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}