using MediatR;
using Microsoft.Extensions.Logging;
using ProjetoAdolescentes.Application.Commands;
using ProjetoAdolescentes.Application.Notification;
using ProjetoAdolescentes.Domain.Interfaces.Core;

namespace ProjetoAdolescentes.Application.Behaviors;

public sealed class TransactionalBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : Command<TResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<TransactionalBehavior<TRequest, TResponse>> _logger;
    private readonly NotificationContext _notificationContext;

    public TransactionalBehavior(IUnitOfWork unitOfWork, ILogger<TransactionalBehavior<TRequest, TResponse>> logger, NotificationContext notificationContext)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _notificationContext = notificationContext;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Beginning transaction for {RequestName}", typeof(TRequest).Name);

        TResponse response = await next();

        if (_notificationContext.HasNotifications)
            return response;

        await _unitOfWork.SaveChangesAsync();

        _logger.LogInformation("Committed transaction for {RequestName}", typeof(TRequest).Name);

        return response;
    }
}