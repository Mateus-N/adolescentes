using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProjetoAdolescentes.CrossCutting.Ioc;
using ProjetoAdolescentes.Infra.Data.Contexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();

builder.Services.RegisterServices(builder.Configuration);

builder.Services.AddLogging(builder =>
{
    builder.AddFilter("Microsoft", LogLevel.None)
           .AddFilter("System", LogLevel.None)
           .AddConsole();
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "AdolescentesApi",
        Version = "v1",
        Description = "Api dos Adolescentes",
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

app.UseStatusCodePages();

app.UseSwagger(c =>
{
    c.RouteTemplate = "Adolescentes/swagger/{documentName}/swagger.{json|yaml}";
});
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/Adolescentes/swagger/v1/swagger.json", "AdolescentesApi v1 (JSON)");
    c.SwaggerEndpoint("/Adolescentes/swagger/v1/swagger.yaml", "AdolescentesApi v1 (YAML)");
    c.RoutePrefix = "Adolescentes/swagger";
});

app.UseAuthorization();

app.MapControllers();

app.Run();