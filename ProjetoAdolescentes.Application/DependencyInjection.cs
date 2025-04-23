using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoAdolescentes.Application.Notification;
using ProjetoAdolescentes.Application.Behaviors;
using ProjetoAdolescentes.Application.Interfaces;
using ProjetoAdolescentes.Application.Services;

namespace ProjetoAdolescentes.Application;

public static class DependencyInjection
{
    public static void RegisterApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<NotificationContext>();

        #region Services
        services.AddScoped<IUsuarioAppService, UsuarioAppService>();
        #endregion

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining<AssemblyReference>();
            cfg.AddOpenBehavior(typeof(PerformanceBehavior<,>));
            cfg.AddOpenBehavior(typeof(ExceptionBehavior<,>));
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
            cfg.AddOpenBehavior(typeof(TransactionalBehavior<,>));
        });

        services.AddValidatorsFromAssembly(typeof(AssemblyReference).Assembly);
    }
}