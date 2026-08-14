using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public sealed class LikeNotification : Notification
    {
        public Guid LikedByUserId { get; private set; }
        public Guid TweetId { get; private set; }

        public LikeNotification(Guid likedByUserId, Guid tweetId) : base(Guid.NewGuid(), NotificationType.Like)
        {
            LikedByUserId = likedByUserId;
            TweetId = tweetId;
        }
        public void AddMessage()
        {
            SetMessage("Someone liked your post", false);
        }
        public override string DescribeRecord()
        {
            var baseRecord = base.DescribeRecord();
            return $"{baseRecord}, LikedByUserId: {LikedByUserId}";
        }
    }
}
