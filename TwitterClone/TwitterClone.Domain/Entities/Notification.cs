using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public abstract class Notification: BaseEntity
    {
       
        public  Guid UserId { get; private set; }
        public NotificationType Type { get; private set; }
        public string Message { get; private set; }
        public bool IsRead { get; private set; } = false;

        public Notification(NotificationType type):base(Guid.NewGuid())
        {
            Type = type;
        }

        protected void SetMessage(string message, bool isRead)
        {
            Message = message;
            IsRead = isRead;
        }


        public abstract string GetMessage();

        public override string DescribeRecord()
        {
            var baseRecord = base.DescribeRecord();
            return $"{baseRecord}, UserId: {UserId}, Type: {Type}, Message: {Message}, IsRead: {IsRead}";
        }

    }

    public enum NotificationType
    {
        Like,
        Comment,
        Retweet,
        Follow,
        Message,
        FriendRequest,
        Mention,
        System
    }
}
