using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    internal class Bookmark
    {
        public Guid _id { get; private set; }
        public Guid _tweetId { get; private set; }
        public Guid _userId { get; private set; }

        public DateTime _createAt { get; private set; }
    }
}
