namespace TwitterClone.Domain.Entities
{
    public class Message : BaseEntity
    {
        public Guid SenderId { get; private set; }
        public Guid ReceiverId { get; private set; }

        public bool IsRead { get; set; } = false;
        public bool IsDeleted { get; private set; } = false;

        public DateTime SentAt { get; private set; }

        public MessageContent Content { get; private set; }

        public Message(
            Guid senderId,
            Guid receiverId,
            MessageContent content,
            DateTime sentAt,
            bool isRead
        ) : base(Guid.NewGuid())
        {
            SenderId = senderId;
            ReceiverId = receiverId;
            Content = content;
            SentAt = sentAt;
            IsRead = isRead;
        }
        public void UpdateContent(MessageContent content)
        {
            ArgumentNullException.ThrowIfNull(content);

            Content = content;
        }



        public override string DescribeRecord()
        {
            var baseRecord = base.DescribeRecord();

            return $"{baseRecord}, Message ID: {Id}, Sender ID: {SenderId}, Receiver ID: {ReceiverId}, Content: {Content.Text}, IsRead: {IsRead}, IsDeleted: {IsDeleted}";
        }
    }
}