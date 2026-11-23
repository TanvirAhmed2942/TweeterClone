namespace TwitterClone.Domain.Entities
{
    public class MessageContent
    {
        public string Text { get; private set; } = string.Empty;
        public string ImageUrl { get; private set; } = string.Empty;

        private MessageContent() { }

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
