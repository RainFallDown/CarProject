using CarProject.Core.Map;
using CarProject.Infrastructure;
using CarProject.Infrastructure.Service;
using Microsoft.OpenApi.Models;
using CarProject.Api.Middleware.Extension;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddInfrastructure();
builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Map));
builder.Services.AddHostedService<VisitConsumerService>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CarProject.Api", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
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

app.Run();
