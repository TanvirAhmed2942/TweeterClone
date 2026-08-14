using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    internal class Bookmark : BaseEntity
    {
        public Guid _userId { get; private set; }
        public Guid _tweetId { get; private set; }

        public Bookmark(Guid userId, Guid tweetId) : base(Guid.NewGuid())
        {
            _userId = userId;
            _tweetId = tweetId;
        }

        public Guid UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public Guid TweetId
        {
            get { return _tweetId; }
            set { _tweetId = value; }
        }

        public override string DescribeRecord()
        {
            var baseRecord = base.DescribeRecord();
            return $"{baseRecord}, User ID: {UserId}, Tweet ID: {TweetId}";
        }
    }
}
