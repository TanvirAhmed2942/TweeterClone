using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class Tweet : BaseEntity, ILikeable, IShareable, ICommentable
    {
        private Guid _userId { get;  set; }
        private string _content { get;  set; }

        private List<Guid> _likes = new List<Guid>();
        private List<Guid> _shares = new List<Guid>();

        private List<Guid> _comments = new List<Guid>();

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
            return $"{baseRecord}, User ID: {UserId}, Content: {Content} , Likes: {_likes.Count}, Shares: {_shares.Count}, Comments: {_comments.Count}";
        }

        public bool CanBeLiked(Guid userId)
        {
           
            if (!_likes.Contains(userId))
            {
                _likes.Add(userId);
                return true;
            }
            
            return false;
        }

  

        public bool CanBeCommented(Guid userId, string comment)
        {
            if (!_comments.Contains(userId) && !string.IsNullOrWhiteSpace(comment))
            {
                _comments.Add(userId);
                return true;
            }
            return false;
        }

        public bool CanBeShared(Guid userId)
        {
            if (!_shares.Contains(userId))
            {
                _shares.Add(userId);
                return true;
            }
            return false;
        }

    }

}
