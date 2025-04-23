using FluentValidation;
using MediatR;
using ProjetoAdolescentes.Application.Commands;
using ProjetoAdolescentes.Application.Notification;

namespace ProjetoAdolescentes.Application.Behaviors;

public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : Command<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    private readonly NotificationContext _notification;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators, NotificationContext notification)
    {
        _validators = validators;
        _notification = notification;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_notification.HasNotifications)
            return (TResponse)Activator.CreateInstance(typeof(TResponse))!;

        if (!_validators.Any())
        {
            return await next(cancellationToken);
        }

        var context = new ValidationContext<TRequest>(request);

        var validationResults = await Task.WhenAll(
            _validators.Select(v =>
                v.ValidateAsync(context, cancellationToken))).ConfigureAwait(true);

        var failures = validationResults
            .Where(r => r.Errors.Count > 0)
            .ToList();

        if (failures.Count > 0)
        {
            _notification.AddNotifications(failures);

            return (TResponse)Activator.CreateInstance(typeof(TResponse))!;
        }

        return await next(cancellationToken);
    }
}