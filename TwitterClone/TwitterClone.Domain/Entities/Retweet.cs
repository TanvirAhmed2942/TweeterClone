using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    internal class Retweet
    {
        public Guid _id { get; set; }
        public Guid _tweetId { get; private set; }
        public Guid _userId { get; private set; }

    }
}
