using TwitterClone.Application.DTOs;

namespace TwitterClone.Application.Interfaces
{
    public interface IFollowService
    {
        FollowDto? CreateFollow(CreateFollowDto createFollowDto);
        FollowDto? GetFollowById(Guid id);
        List<FollowDto> GetFollows(Guid? followerId, Guid? followingId);
        List<ResponseUserDto?> GetFollowers(Guid userId);
        List<ResponseUserDto?> GetFollowing(Guid userId);
        bool DeleteFollow(Guid id);
    }
    public class CreateFollowDto
    {
        public required Guid FollowerId { get; set; }
        public required Guid FollowingId { get; set; }
    }
}
