using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoAdolescentes.Application;
using ProjetoAdolescentes.Domain;
using ProjetoAdolescentes.Infra.Data;

namespace ProjetoAdolescentes.CrossCutting.Ioc;

public static class DependencyInjection
{
    public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<HttpClient>();

        services.AddSingleton<IConfiguration>(configuration);

        services.RegisterApplicationServices(configuration);

        services.RegisterDomainServices();

        services.RegisterInfraDataServices(configuration);
    }
}