using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Repositories
{
    public class TweetRepository : ITweetRepository
    {
        private readonly List<Tweet> _tweets = [];

        public Tweet AddTweet(Tweet tweet)
        {
            _tweets.Add(tweet);
            return tweet;
        }

        public List<Tweet> GetAllTweets()
        {
            return _tweets;
        }

        public Tweet? FetchTweetById(Guid tweetId)
        {
            return _tweets.FirstOrDefault(t => t.Id == tweetId);
        }

        public List<Tweet>? FetchTweetsByUserId(Guid userId)
        {
            return [.. _tweets.Where(t => t.UserId == userId)];
        }


        public bool IsFoundById(Guid tweetId)
        {
            return _tweets.Any(t => t.Id == tweetId);
        }

        public Tweet? ModifyContent(Guid tweetId, string content)
        {
            var tweet = _tweets.SingleOrDefault(t => t.Id == tweetId);
            if (tweet == null)
            {
                return null;
            }

            tweet?.Content = content;


            return tweet;
        }

        public Tweet? DeleteById(Guid tweetId)
        {
            var tweet = _tweets.SingleOrDefault(t => t.Id == tweetId);

            if (tweet == null)
                return null;

            _tweets.Remove(tweet);

            return tweet;
        }


    }
}
