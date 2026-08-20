using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public sealed class LikeNotification : Notification
    {
        public Guid LikedByUserId { get; private set; }
        public Guid TweetId { get; private set; }

        public LikeNotification( Guid tweetId, Guid likedByUserId) : base(NotificationType.Like)
        {
            
            TweetId = tweetId;
            LikedByUserId = likedByUserId;
        }
        public void AddMessage()
        {
            SetMessage("Someone liked your post", false);
        }

        public override string GetMessage()
        {
            return $"User with ID {LikedByUserId} liked your post.";
        }
        public override string DescribeRecord()
        {
            var baseRecord = base.DescribeRecord();
            return $"{baseRecord}, LikedByUserId: {LikedByUserId}, TweetId: {TweetId} ,NotificationType: {Type}";
        }
    }
}
