using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class Notification: BaseEntity
    {
       
        public  Guid UserId { get; private set; }
        public NotificationType Type { get; private set; }
        public string Message { get; private set; }
        public bool IsRead { get; private set; } = false;

        public Notification(Guid userId, NotificationType type):base(Guid.NewGuid())
        {
           
            UserId = userId;
            Type = type;
            
        }

        protected void SetMessage(string message, bool isRead)
        {
            Message = message;
            IsRead = isRead;
        }

       

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
        System
    }
}
