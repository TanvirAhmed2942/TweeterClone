using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    internal class Message : BaseEntity
    {
        public Guid SenderId { get; private set; }
        public Guid ReceiverId { get; private set; }
        public bool IsRead { get; private set; } = false;
        public bool IsDeleted { get; private set; } = false;

        public MessageContent Content { get; private set; }
        public Message(Guid senderId, Guid receiverId, MessageContent content) : base(Guid.NewGuid())
        {
            SenderId = senderId;
            ReceiverId = receiverId;
            Content = content;
        }


        public override string DescribeRecord()
        {
            var baseRecord = base.DescribeRecord();
            return $"{baseRecord}, Message ID: {Id}, Sender ID: {SenderId}, Receiver ID: {ReceiverId}, Content: {Content} , IsRead: {IsRead}, IsDeleted: {IsDeleted}";
        }
    }
    
    
}
