using System.ComponentModel.DataAnnotations;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.DTOs
{
    public class NotificationDto
    {
        public required Guid Id { get; set; }
        public required Guid UserId { get; set; }
        public required NotificationType Type { get; set; }
        public required string Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }

    public class CreateNotificationDto : IValidatableObject
    {
        public required Guid UserId { get; set; }

        [Required]
        [RegularExpression(
            "^(Like|Comment|Retweet|Follow|Message|FriendRequest|Mention|System)$",
            ErrorMessage = "Type must be one of: Like|Comment|Retweet|Follow|Message|FriendRequest|Mention|System")]
        public required string Type { get; set; }

        public Guid? TriggeredByUserId { get; set; }

        // Required when creating a Like notification.
        public Guid? TweetId { get; set; }

        public IEnumerable<ValidationResult> Validate(
            ValidationContext validationContext)
        {
            if (Type != "System" && TriggeredByUserId == null)
            {
                yield return new ValidationResult(
                    "TriggeredByUserId is required for this notification type.",
                    new[] { nameof(TriggeredByUserId) });
            }

            if (Type == "Like" && TweetId == null)
            {
                yield return new ValidationResult(
                    "TweetId is required for a Like notification.",
                    new[] { nameof(TweetId) });
            }
        }
    }
}
