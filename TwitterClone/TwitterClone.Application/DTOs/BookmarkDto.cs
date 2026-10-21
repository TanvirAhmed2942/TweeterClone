namespace TwitterClone.Application.DTOs
{
    public class BookmarkDto
    {
        public required Guid Id { get; set; }
        public required Guid UserId { get; set; }
        public required Guid TweetId { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class CreateBookmarkDto
    {
        public required Guid UserId { get; set; }
        public required Guid TweetId { get; set; }
    }
}
