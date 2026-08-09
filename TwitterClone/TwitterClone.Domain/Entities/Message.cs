using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    internal class Message
    {
        public Guid _id { get; private set; }
        public Guid _senderId { get; private set; }
        public Guid _recevierId { get; private set; }
        public MessageContent _content { get; private set; }

        public DateTime _sentAt { get; private set; }
        public DateTime _editedAt { get; private set; }
    }
}
