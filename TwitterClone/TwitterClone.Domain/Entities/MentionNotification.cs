using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class MentionNotification : Notification
    {
        public Guid MentionedByUserId { get; private set; }
        public Guid TweetId { get; private set; }
        public MentionNotification(Guid mentionedByUserId, Guid tweetId) : base(NotificationType.Mention)
        {
            MentionedByUserId = mentionedByUserId;
            TweetId = tweetId;
        }
        public void AddMessage()
        {
            SetMessage("Someone mentioned you in a post", false);
        }
        public override string GetMessage()
        {
            return $"User with ID {MentionedByUserId} mentioned you in a post.";
        }
        public override string DescribeRecord()
        {
            var baseRecord = base.DescribeRecord();
            return $"{baseRecord}, MentionedByUserId: {MentionedByUserId}, TweetId: {TweetId} ,NotificationType: {Type}";
        }
    }
}
