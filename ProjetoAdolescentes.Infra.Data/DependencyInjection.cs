using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoAdolescentes.Domain.Interfaces.Core;
using ProjetoAdolescentes.Domain.Interfaces.Repositories;
using ProjetoAdolescentes.Infra.Data.Contexts;
using ProjetoAdolescentes.Infra.Data.Repositories;

namespace ProjetoAdolescentes.Infra.Data;

public static class DependencyInjection
{
    public static void RegisterInfraDataServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AdolescentesContext>(options => 
            options
                .UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
                .UseSnakeCaseNamingConvention()
        );

        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

        #region Repositories

        services.AddScoped<IUsuarioRepository, UsuarioRepository>();

        #endregion
    }
}