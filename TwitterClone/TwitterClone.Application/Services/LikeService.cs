using TwitterClone.Application.DTOs;
using TwitterClone.Application.Interfaces;
using TwitterClone.Application.Mappings;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Services
{
    public class LikeService : ILikeService
    {
        private readonly ILikeRepository _likeRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITweetRepository _tweetRepository;
        public LikeService(
           ILikeRepository likeRepository,
           IUserRepository userRepository,
           ITweetRepository tweetRepository)
        {
            _likeRepository = likeRepository;
            _userRepository = userRepository;
            _tweetRepository = tweetRepository;
        }

        public LikeDto? CreateLike(CreateLikeDto createLikeDto)
        {
            var user = _userRepository.IsFoundById(createLikeDto.UserId);
            var tweet = _tweetRepository.FetchTweetById(createLikeDto.TweetId);

            if (user == null || tweet == null || !tweet.CanBeLiked())
            {
                return null;
            }
            var existingLike = _likeRepository.GetLikeByUserAndTweet(user.Id, tweet.Id);

            if (existingLike != null)
            {
                return existingLike.ToDto();
            }

            var createdLike = _likeRepository.AddLike(new Like(user.Id, tweet.Id));

            return createdLike.ToDto();
        }

        public bool DeleteLike(Guid id)
        {
            throw new NotImplementedException();
        }

        public LikeDto? GetLikeById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<LikeDto> GetLikes(Guid? userId, Guid? tweetId)
        {
            throw new NotImplementedException();
        }
    }
}
