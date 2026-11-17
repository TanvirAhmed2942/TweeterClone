using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Persistence;

namespace TwitterClone.Infrastructure.Repositories
{
    public class TweetRepository : ITweetRepository
    {
        private readonly TwitterCloneDbContext _dbContext;

        public TweetRepository(TwitterCloneDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Tweet AddTweet(Tweet tweet)
        {
            _dbContext.Tweets.Add(tweet);
            return tweet;
        }

        public List<Tweet> GetAllTweets()
        {
            return _dbContext.Tweets.ToList();
        }

        public Tweet? FetchTweetById(Guid tweetId)
        {
            return _dbContext.Tweets.FirstOrDefault(t => t.Id == tweetId);
        }

        public List<Tweet>? FetchTweetsByUserId(Guid userId)
        {
            return [.. _dbContext.Tweets.Where(t => t.UserId == userId)];
        }


        public bool IsFoundById(Guid tweetId)
        {
            return _dbContext.Tweets.Any(t => t.Id == tweetId);
        }

        public Tweet? ModifyContent(Guid tweetId, string content)
        {
            var tweet = _dbContext.Tweets.SingleOrDefault(t => t.Id == tweetId);
            if (tweet == null)
            {
                return null;
            }

            tweet?.Content = content;


            return tweet;
        }

        public Tweet? DeleteById(Guid tweetId)
        {
            var tweet = _dbContext.Tweets.SingleOrDefault(t => t.Id == tweetId);

            if (tweet == null)
                return null;

            _dbContext.Tweets.Remove(tweet);

            return tweet;
        }


    }
}
