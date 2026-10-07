namespace TwitterClone.Application.DTOs
{
    public class CreateTweetDto
    {
        public Guid UserId { get; set; }
        public string Content { get; set; }

    }
}
