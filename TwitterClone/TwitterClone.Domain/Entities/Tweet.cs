using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    internal class Tweet : BaseEntity
    {
        public Guid _userId { get; private set; }
        public string _content { get; private set; }

        public Tweet(Guid userId, string content) : base(Guid.NewGuid())
        {
            _userId = userId;
            _content = content;

        }
        public Guid UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }

        public override string DescribeRecord()
        {
            var baseRecord = base.DescribeRecord();
            return $"{baseRecord}, User ID: {UserId}, Content: {Content}";
        }

    }

}
