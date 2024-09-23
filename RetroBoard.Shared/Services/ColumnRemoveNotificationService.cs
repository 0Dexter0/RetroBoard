namespace RetroBoard.Shared.Services;

public class ColumnRemoveNotificationService
{
    public event Func<Task> Notification;

    public Task NotifyAsync() => Notification?.Invoke();
}