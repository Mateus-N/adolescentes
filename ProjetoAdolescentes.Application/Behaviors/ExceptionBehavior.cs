using MediatR;
using Microsoft.Extensions.Logging;
using ProjetoAdolescentes.Domain.Interfaces.Core;
using System.Reflection;

namespace ProjetoAdolescentes.Application.Behaviors;

internal sealed class ExceptionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<ExceptionBehavior<TRequest, TResponse>> _logger;

    public ExceptionBehavior(IUnitOfWork unitOfWork, ILogger<ExceptionBehavior<TRequest, TResponse>> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        try
        {
            var response = await next(cancellationToken);
            return response;
        }
        catch (Exception ex)
        {
            var requestData = ExtractRequestData(request);

            var logMessage = $"Unhandled exception for Request {{RequestName}}. Request Data: {{@RequestData}}";
            var logParams = new List<object> { typeof(TRequest).Name, requestData };

            if (!string.IsNullOrEmpty(ex.InnerException?.Message))
            {
                logMessage += ". Inner Exception: {InnerException}";
                logParams.Add(ex.InnerException.Message);
            }

            _logger.LogError(ex, logMessage, [.. logParams]);

            throw;
        }
    }

    private string ExtractRequestData(TRequest request)
    {
        var requestProperties = request.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var requestData = new Dictionary<string, object>();

        foreach (var property in requestProperties)
        {
            requestData[property.Name] = property.GetValue(request)!;
        }

        return System.Text.Json.JsonSerializer.Serialize(requestData);
    }
}