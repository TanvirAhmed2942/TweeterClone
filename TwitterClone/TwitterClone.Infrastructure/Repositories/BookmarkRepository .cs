using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Persistence;

namespace TwitterClone.Infrastructure.Repositories
{
    public class BookmarkRepository : IBookmarkRepository
    {

        private readonly TwitterCloneDbContext _dbContext;
        public BookmarkRepository(TwitterCloneDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Bookmark AddBookmark(Bookmark bookmark)
        {
            _dbContext.Bookmarks.Add(bookmark);

            return bookmark;
        }

        public bool DeleteBookmark(Bookmark bookmark)
        {
            _dbContext.Bookmarks.Remove(bookmark);
            return true;
        }

        public int DeleteBookmarksByUserId(Guid userId)
        {
            var bookmarks = _dbContext.Bookmarks.Where(b => b.UserId == userId);
            _dbContext.Bookmarks.RemoveRange(bookmarks);
            return bookmarks.Count();
        }

        public int DeleteBookmarksByTweetId(Guid tweetId)
        {
            var bookmarks = _dbContext.Bookmarks.Where(b => b.TweetId == tweetId);
            _dbContext.Bookmarks.RemoveRange(bookmarks);
            return bookmarks.Count();
        }

        public Bookmark? GetBookmarkById(Guid id)
        {
            return _dbContext.Bookmarks.SingleOrDefault(b => b.Id == id);
        }

        public Bookmark? GetBookmarkByUserAndTweet(Guid userId, Guid tweetId)
        {
            return _dbContext.Bookmarks.FirstOrDefault(b => b.UserId == userId && b.TweetId == tweetId);
        }

        public List<Bookmark> GetBookmarks(Guid? userId)
        {
            return _dbContext.Bookmarks
                .Where(b => userId == null || b.UserId == userId)
                .ToList();
        }
    }
}
