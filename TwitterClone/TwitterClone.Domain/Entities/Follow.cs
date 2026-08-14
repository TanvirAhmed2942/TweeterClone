using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    internal class Follow : BaseEntity
    {
        
        private Guid _followerId;
        private Guid _followingId;


        public Follow(Guid followerId, Guid followingId) : base(Guid.NewGuid())
        {
            _followerId = followerId;
            _followingId = followingId;
        }

        
        public Guid FollowerId
        {
            get { return _followerId; }
            set { _followerId = value; }
        }

        public Guid FollowingId
        {
            get { return _followingId; }
            set { _followingId = value; }
        }

        public override string DescribeRecord()
        {
            var baseRecord = base.DescribeRecord();
            return $"{baseRecord}, Follower ID: {FollowerId}, Following ID: {FollowingId}";
        }
    }
}
