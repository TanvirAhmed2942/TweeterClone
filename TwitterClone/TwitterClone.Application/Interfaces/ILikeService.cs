using TwitterClone.Application.DTOs;

namespace TwitterClone.Application.Interfaces
{
    public interface ILikeService
    {
        LikeDto? CreateLike(CreateLikeDto createLikeDto);
        LikeDto? GetLikeById(Guid id);
        List<LikeDto> GetLikes(Guid? userId, Guid? tweetId);
        bool DeleteLike(Guid id);
    }

    public class CreateLikeDto
    {
        public required Guid UserId { get; set; }
        public required Guid TweetId { get; set; }
    }
}
