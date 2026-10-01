namespace TwitterClone.Api.DTOs
{
    public class CreateTweetDto
    {
        public Guid UserId { get; set; }
        public string Content { get; set; }

    }
}
