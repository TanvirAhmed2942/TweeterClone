using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    internal class Retweet : BaseEntity
    {
        private Guid _userId;
        private Guid _tweetId;
        private string _comment;

        public Retweet(Guid userId, Guid tweetId, string comment) : base(Guid.NewGuid())
        {
            _userId = userId;
            _tweetId = tweetId;
            _comment = comment;
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

        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }

        public override string DescribeRecord()
        {
            var baseRecord = base.DescribeRecord();
            return $"{baseRecord}, User ID: {UserId}, Tweet ID: {TweetId}, Comment: {Comment}";
        }
    }
}

