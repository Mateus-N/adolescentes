using FluentValidation.Results;

namespace ProjetoAdolescentes.Application.Notification;

public class NotificationContext
{
    private List<Notification> _notifications;
    public IReadOnlyCollection<Notification> Notifications => _notifications;
    public bool HasNotifications => _notifications.Count != 0;

    public NotificationContext()
    {
        _notifications = new List<Notification>();
    }

    public void AddNotification(string key, string message)
    {
        _notifications.Add(new Notification(key, message));
    }

    public void AddNotification(Notification notification)
    {
        _notifications.Add(notification);
    }

    public void AddNotifications(IReadOnlyCollection<Notification> notifications)
    {
        _notifications.AddRange(notifications);
    }

    public void AddNotifications(IList<Notification> notifications)
    {
        _notifications.AddRange(notifications);
    }

    public void AddNotifications(ICollection<Notification> notifications)
    {
        _notifications.AddRange(notifications);
    }

    public void AddNotifications(ValidationResult validationResult)
    {
        foreach (var error in validationResult.Errors)
        {
            AddNotification(error.ErrorCode, error.ErrorMessage);
        }
    }

    public void AddNotifications(IEnumerable<ValidationResult> validationResults)
    {
        foreach (var validationResult in validationResults)
        {
            AddNotifications(validationResult);
        }
    }

    public void Clear()
    {
        _notifications = new List<Notification>();
    }
}