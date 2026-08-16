using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public sealed class CommentNotification : Notification
    {
        public Guid CommentedOnUserId { get; private set; }
        public Guid TweetId { get; private set; }
        public CommentNotification(Guid commentedOnUserId , Guid tweetId) : base(NotificationType.Comment)
        {
            CommentedOnUserId = commentedOnUserId;
            TweetId = tweetId;
        }
        public void AddMessage()
        {
            SetMessage("Someone commented on your post", false);
        }

        public override string GetMessage()
        {
            return $"User with ID {CommentedOnUserId} commented on your post.";
        }
        public override string DescribeRecord()
        {
            var baseRecord = base.DescribeRecord();
            return $"{baseRecord}, CommentedOnUserId: {CommentedOnUserId}, TweetId: {TweetId} ,NotificationType: {Type}";
        }
    }
}
