using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Data
{
    public class TweetRepository
    {
        private List<Tweet> _tweets = new List<Tweet>();

        public Tweet AddTweet(Tweet tweet)
        {
            _tweets.Add(tweet);
            return tweet;
        }

        public IEnumerable<Tweet> GetAllTweets()
        {
            return _tweets;
        }

        public Tweet? FetchTweetById(Guid tweetId)
        {
            return _tweets.FirstOrDefault(t => t.Id == tweetId);
        }

        public List<Tweet>? FetchTweetsByUserId(Guid userId)
        {
            return _tweets
            .Where(t => t.UserId == userId)
            .ToList();
        }
        

        public bool IsFoundById(Guid tweetId)
        {
            return _tweets.Any(t => t.Id == tweetId);
        }

        public Tweet ModifyContent(Guid tweetId,string content)
        {
            var tweet = _tweets.SingleOrDefault(t => t.Id == tweetId);

            tweet.Content = content;
            

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
