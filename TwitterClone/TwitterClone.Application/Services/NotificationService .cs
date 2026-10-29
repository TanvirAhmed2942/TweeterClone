using TwitterClone.Application.DTOs;
using TwitterClone.Application.Interfaces;
using TwitterClone.Application.Mappings;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IUserRepository _userRepository;

        public NotificationService(
            INotificationRepository notificationRepository,
            IUserRepository userRepository)
        {
            _notificationRepository = notificationRepository;
            _userRepository = userRepository;
        }
        public List<NotificationDto>? GetNotifications(Guid? userId, NotificationType? type, bool? isRead)
        {

            // Newest first.
            return _notificationRepository.GetNotifications(userId, type, isRead)
                .OrderByDescending(n => n.CreatedAt)
                .Select(n => n.ToDto())
                .ToList();
        }
        public NotificationDto? CreateNotification(CreateNotificationDto createNotificationDto)
        {
            if (_userRepository.FetchUserById(createNotificationDto.UserId) == null)
            {
                return null;
            }

            if (createNotificationDto.TriggeredByUserId.HasValue &&
                _userRepository.FetchUserById(createNotificationDto.TriggeredByUserId.Value) == null)
            {
                return null;
            }

            var notification = BuildNotification(createNotificationDto);

            if (notification == null)
            {
                return null;
            }

            notification.UserId = createNotificationDto.UserId;

            var createdNotification = _notificationRepository.AddNotification(notification);

            return createdNotification.ToDto();
        }

        public NotificationDto? GetNotificationById(Guid id)
        {
            var notification = _notificationRepository.GetNotificationById(id);

            return notification?.ToDto();
        }



        public NotificationDto? MarkNotificationAsRead(Guid id)
        {
            var notification = _notificationRepository.GetNotificationById(id);

            if (notification == null)
            {
                return null;
            }

            MarkAsRead(notification);

            return notification.ToDto();
        }

        public int MarkAllNotificationsAsRead(Guid userId)
        {
            var unreadNotifications =
                _notificationRepository.GetNotifications(userId, null, false)
                ?? new List<Notification>();

            foreach (var notification in unreadNotifications)
            {
                MarkAsRead(notification);
            }

            return unreadNotifications.Count;
        }

        public bool DeleteNotification(Guid id)
        {
            var notification = _notificationRepository.GetNotificationById(id);

            if (notification == null)
            {
                return false;
            }

            return _notificationRepository.DeleteNotification(notification);
        }

        private void MarkAsRead(Notification notification)
        {
            if (notification.IsRead)
            {
                return;
            }

            notification.IsRead = true;
            notification.MarkAsModified();

            _notificationRepository.UpdateNotification(notification);
        }

        private static Notification? BuildNotification(
     CreateNotificationDto createNotificationDto)
        {
            var triggeredByUserId =
                createNotificationDto.TriggeredByUserId ?? Guid.Empty;

            return createNotificationDto.Type switch
            {
                "Like" when createNotificationDto.TweetId.HasValue =>
                    new LikeNotification(
                        createNotificationDto.TweetId.Value,
                        triggeredByUserId),

                "Comment" when createNotificationDto.TweetId.HasValue =>
                    new CommentNotification(triggeredByUserId, createNotificationDto.TweetId.Value),
                "Mention" when createNotificationDto.TweetId.HasValue =>
                    new MentionNotification(triggeredByUserId, createNotificationDto.TweetId.Value),
                "FriendRequest" => new FriendRequestNotification(triggeredByUserId),
                "System" => new SystemNotification(),

                _ => null
            };
        }
    }
}
