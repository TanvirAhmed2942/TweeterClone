using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    internal class Notification
    {
        public Guid _id { get; private set; }
        public Guid _receiverId { get; private set; }
        public string _title { get; private set; }
        public string _message { get; private set; }

        public NotificationType _type { get; private set; }

    }

    internal enum NotificationType
    {
        Like,
        Retweet,
        Follow,
        Message
    }
}
