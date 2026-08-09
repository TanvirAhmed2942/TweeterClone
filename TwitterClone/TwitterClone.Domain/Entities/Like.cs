using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    internal class Like
    {
        public Guid _id { get; private set; }

        public Guid _tweetId { get; private set; }

        public DateTime _likedAt { get; private set; }
    }
}
