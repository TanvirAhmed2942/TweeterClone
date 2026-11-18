using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Persistence;

namespace TwitterClone.Infrastructure.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly TwitterCloneDbContext _dbContext;

        public NotificationRepository(TwitterCloneDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Notification AddNotification(Notification notification)
        {
            _dbContext.Notifications.Add(notification);

            return notification;
        }

        public Notification UpdateNotification(Notification notification)
        {
            _dbContext.Notifications.Remove(notification);
            _dbContext.Notifications.Add(notification);
            return notification;
        }

        public bool DeleteNotification(Notification notification)
        {
            _dbContext.Notifications.Remove(notification);
            return true;
        }

        public int DeleteNotificationsByUserId(Guid userId)
        {
            var notifications = _dbContext.Notifications.Where(n => n.UserId == userId);
            _dbContext.Notifications.RemoveRange(notifications);
            return notifications.Count();
        }

        public Notification? GetNotificationById(Guid id)
        {
            return _dbContext.Notifications.SingleOrDefault(n => n.Id == id);
        }

        public List<Notification> GetNotifications(
    Guid? userId,
    NotificationType? type,
    bool? isRead)
        {
            return _dbContext.Notifications
                .Where(n =>
                    (userId == null || n.UserId == userId) &&
                    (type == null || n.Type == type) &&
                    (isRead == null || n.IsRead == isRead))
                .ToList();
        }
    }
}
