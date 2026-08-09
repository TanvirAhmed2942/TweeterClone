using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    internal class Tweet
    {
        public Guid _id { get; private set; }
        public Guid _authorId { get; private set; }
        public string _content { get; set; }
    }
}
