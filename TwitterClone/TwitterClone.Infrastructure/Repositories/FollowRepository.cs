using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Persistence;

namespace TwitterClone.Infrastructure.Repositories
{
    public class FollowRepository : IFollowRepository
    {

        private readonly TwitterCloneDbContext _dbContext;

        public FollowRepository(TwitterCloneDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Follow AddFollow(Follow follow)
        {
            _dbContext.Follows.Add(follow);

            return follow;
        }

        public bool DeleteFollow(Follow follow)
        {
            _dbContext.Follows.Remove(follow);
            return true;
        }

        // Removes the follows where the user is either side of the relationship.
        public int DeleteFollowsByUserId(Guid userId)
        {
            var follows = _dbContext.Follows.Where(f => f.FollowerId == userId || f.FollowingId == userId);
            _dbContext.Follows.RemoveRange(follows);
            return follows.Count();
        }

        public Follow? GetFollowById(Guid id)
        {
            return _dbContext.Follows.SingleOrDefault(f => f.Id == id);
        }

        public Follow? GetFollowByUsers(Guid followerId, Guid followingId)
        {
            return _dbContext.Follows.FirstOrDefault(f => f.FollowerId == followerId && f.FollowingId == followingId);
        }

        public List<Follow> GetFollows(Guid? followerId, Guid? followingId)
        {
            return _dbContext.Follows
                .Where(f => (followerId == null || f.FollowerId == followerId) &&
                            (followingId == null || f.FollowingId == followingId))
                .ToList();
        }
    }
}
