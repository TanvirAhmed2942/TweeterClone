using TwitterClone.Application.DTOs;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Interfaces
{
    public interface INotificationService
    {
        NotificationDto? CreateNotification(CreateNotificationDto createNotificationDto);
        NotificationDto? GetNotificationById(Guid id);
        List<NotificationDto>? GetNotifications(Guid? userId, NotificationType? type, bool? isRead);
        NotificationDto? MarkNotificationAsRead(Guid id);
        int MarkAllNotificationsAsRead(Guid userId);
        bool DeleteNotification(Guid id);
    }
}
