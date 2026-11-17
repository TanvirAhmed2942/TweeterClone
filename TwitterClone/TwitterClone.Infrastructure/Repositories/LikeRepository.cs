using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Persistence;

namespace TwitterClone.Infrastructure.Repositories
{
    public class LikeRepository : ILikeRepository
    {


        private readonly TwitterCloneDbContext _dbContext;
        public LikeRepository(TwitterCloneDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Like AddLike(Like like)
        {
            _dbContext.Likes.Add(like);

            return like;
        }

        public bool DeleteLike(Like like)
        {
            _dbContext.Likes.Remove(like);
            return true;
        }

        public int DeleteLikesByUserId(Guid userId)
        {
            var likes = _dbContext.Likes.Where(l => l.UserId == userId);
            _dbContext.Likes.RemoveRange(likes);
            return likes.Count();
        }

        public int DeleteLikesByTweetId(Guid tweetId)
        {
            var likes = _dbContext.Likes.Where(l => l.TweetId == tweetId);
            _dbContext.Likes.RemoveRange(likes);
            return likes.Count();
        }

        public Like? GetLikeById(Guid id)
        {
            return _dbContext.Likes.SingleOrDefault(l => l.Id == id);
        }

        public Like? GetLikeByUserAndTweet(Guid userId, Guid tweetId)
        {
            return _dbContext.Likes.FirstOrDefault(l => l.UserId == userId && l.TweetId == tweetId);
        }

        public List<Like> GetLikes(Guid? userId, Guid? tweetId)
        {
            return _dbContext.Likes
                .Where(l => (userId == null || l.UserId == userId) &&
                            (tweetId == null || l.TweetId == tweetId))
                .ToList();
        }
    }
}