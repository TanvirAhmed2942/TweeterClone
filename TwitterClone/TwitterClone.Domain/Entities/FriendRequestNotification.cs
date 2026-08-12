using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public sealed class FriendRequestNotification : Notification
    {
        public Guid RequestedByUserId { get; set; }
        public FriendRequestNotification(Guid requestedByUserId) : base(Guid.NewGuid(), NotificationType.FriendRequest)
        {
            RequestedByUserId = requestedByUserId;
        }

        public void AddMessage()
        {
            SetMessage("You have a new friend request", false);
        }


        public override string DescribeRecord()
        {
            var baseRecord = base.DescribeRecord();
            return $"{baseRecord}, RequestedByUserId: {RequestedByUserId}";
        }
    }
}
