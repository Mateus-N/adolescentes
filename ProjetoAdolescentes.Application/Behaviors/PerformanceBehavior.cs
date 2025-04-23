using MediatR;
using Microsoft.Extensions.Logging;
using ProjetoAdolescentes.Domain.Interfaces.Core;

namespace ProjetoAdolescentes.Application.Behaviors;

internal sealed class PerformanceBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<PerformanceBehavior<TRequest, TResponse>> _logger;

    public PerformanceBehavior(IUnitOfWork unitOfWork, ILogger<PerformanceBehavior<TRequest, TResponse>> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        System.Timers.Timer timer = new();

        timer.Start();

        TResponse response = await next();

        timer.Stop();

        if (timer.Interval > 1000)
        {
            _logger.LogWarning("Long Running Request: {RequestName} ({ElapsedMilliseconds} milliseconds)", typeof(TRequest).Name, timer.Interval);
        }

        return response;
    }
}