using TwitterClone.Application.DTOs;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Interfaces
{
    public interface ITweetService
    {
        public Tweet AddTweet(CreateTweetDto createTweetDto1);
        public List<Tweet>? GetAllTweets();
        public Tweet? FetchTweetById(Guid tweetId);
        public List<Tweet>? FetchTweetsByUserId(Guid userId);
        public bool IsFoundById(Guid tweetId);
        public Tweet ModifyContent(Guid tweetId, string content);
        public Tweet DeleteById(Guid tweetId);
    }
}
