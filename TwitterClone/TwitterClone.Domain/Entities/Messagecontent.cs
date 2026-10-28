namespace TwitterClone.Domain.Entities
{
    public class MessageContent
    {
        public string Text { get; }
        public string ImageUrl { get; }

        public MessageContent(string text, string imageUrl)
        {
            Text = text?.Trim() ?? string.Empty;
            ImageUrl = imageUrl?.Trim() ?? string.Empty;
        }

        public bool IsEmpty =>
            string.IsNullOrWhiteSpace(Text) &&
            string.IsNullOrWhiteSpace(ImageUrl);
    }
}
