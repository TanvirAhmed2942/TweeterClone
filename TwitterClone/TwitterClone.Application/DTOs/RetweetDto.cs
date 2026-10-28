using System.ComponentModel.DataAnnotations;

namespace TwitterClone.Application.DTOs
{
    public class RetweetDto
    {
        public required Guid Id { get; set; }
        public required Guid UserId { get; set; }
        public required Guid TweetId { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }

    public class CreateRetweetDto : IValidatableObject
    {
        public required Guid UserId { get; set; }
        public required Guid TweetId { get; set; }

        // Optional: a retweet without a comment is a plain retweet.
        public string? Comment { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return RetweetCommentValidator.Validate(Comment, nameof(Comment));
        }
    }


    public class UpdateRetweetDto : IValidatableObject
    {
        public string? Comment { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return RetweetCommentValidator.Validate(Comment, nameof(Comment));
        }
    }
}
