namespace TwitterClone.Domain.Entities
{
    public class Tweet : BaseEntity, ILikeable, IShareable, ICommentable
    {
        public const int MaxContentLength = 280;

        private Guid _userId;
        private string _content = string.Empty;

        private List<Guid> _likes = new List<Guid>();
        private List<Guid> _shares = new List<Guid>();
        private List<Guid> _comments = new List<Guid>();

        // Navigation property: nullable, EF fills it via .Include(t => t.User)
        public User? User { get; set; }

        public Tweet(Guid userId, string content) : base(Guid.NewGuid())
        {
            _userId = userId;
            _content = content;
        }

        // For EF Core
        private Tweet() : base(Guid.NewGuid()) { }

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

        public bool CanBeLiked()
        {
            return !string.IsNullOrWhiteSpace(Content);
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