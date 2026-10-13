using TwitterClone.Application.DTOs;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Services
{
    public class TweetService : ITweetService
    {
        private readonly ITweetRepository _tweetRepository;
        public TweetService(ITweetRepository tweetRepository)
        {
            _tweetRepository = tweetRepository;
        }

        public Tweet? AddTweet(CreateTweetDto createTweetDto)
        {
            if (createTweetDto == null || string.IsNullOrWhiteSpace(createTweetDto.Content))
            {
                return null;
            }
            var tweet = new Tweet(createTweetDto.UserId, createTweetDto.Content);
            var addedTweet = _tweetRepository.AddTweet(tweet);
            if (addedTweet == null)
            {
                return null;
            }
            return addedTweet;
        }

        public Tweet? DeleteById(Guid tweetId)
        {
            var tweet = _tweetRepository.DeleteById(tweetId);
            if (tweet == null)
            {
                return null;
            }
            return tweet;
        }

        public Tweet? FetchTweetById(Guid tweetId)
        {
            var tweet = _tweetRepository.FetchTweetById(tweetId);
            if (tweet == null)
            {
                return null;
            }
            return tweet;
        }

        public List<Tweet>? FetchTweetsByUserId(Guid userId)
        {
            var tweetsByUser = _tweetRepository.FetchTweetsByUserId(userId);
            if (tweetsByUser == null || !tweetsByUser.Any())
            {
                return null;
            }
            return tweetsByUser;
        }

        public List<Tweet>? GetAllTweets()
        {
            var allTweets = _tweetRepository.GetAllTweets();
            if (allTweets == null || !allTweets.Any())
            {
                return null;
            }
            return allTweets;

        }

        public bool? IsFoundById(Guid tweetId)
        {

            bool found = _tweetRepository.IsFoundById(tweetId);

            if (!found)
            {
                return false;
            }
            return true;
        }

        public Tweet? ModifyContent(Guid tweetId, string content)
        {
            var tweet = _tweetRepository.ModifyContent(tweetId, content);
            if (tweet == null)
            {
                return null;
            }
            return tweet;
        }
    }
}
