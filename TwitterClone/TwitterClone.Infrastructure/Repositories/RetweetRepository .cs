using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Persistence;

namespace TwitterClone.Infrastructure.Repositories
{
    public class RetweetRepository : IRetweetRepository
    {
        private readonly TwitterCloneDbContext _dbContext;

        public RetweetRepository(TwitterCloneDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Retweet AddRetweet(Retweet retweet)
        {
            _dbContext.Retweets.Add(retweet);

            return retweet;
        }

        public Retweet UpdateRetweet(Retweet retweet)
        {
            _dbContext.Retweets.Remove(retweet);
            _dbContext.Retweets.Add(retweet);
            return retweet;
        }

        public bool DeleteRetweet(Retweet retweet)
        {
            _dbContext.Retweets.Remove(retweet);
            return true;
        }

        public int DeleteRetweetsByUserId(Guid userId)
        {
            var retweets = _dbContext.Retweets.Where(r => r.UserId == userId);
            _dbContext.Retweets.RemoveRange(retweets);
            return retweets.Count();
        }

        public int DeleteRetweetsByTweetId(Guid tweetId)
        {
            var retweets = _dbContext.Retweets.Where(r => r.TweetId == tweetId);
            _dbContext.Retweets.RemoveRange(retweets);
            return retweets.Count();
        }

        public Retweet? GetRetweetById(Guid id)
        {
            return _dbContext.Retweets.SingleOrDefault(r => r.Id == id);
        }

        public List<Retweet> GetRetweets(Guid? userId, Guid? tweetId)
        {
            return _dbContext.Retweets
                .Where(r => (userId == null || r.UserId == userId) &&
                            (tweetId == null || r.TweetId == tweetId))
                .ToList();
        }
    }
}
