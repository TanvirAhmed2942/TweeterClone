using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetFollows()
        {
            var follows = new[]
            {
                new { FollowId = Guid.NewGuid(), UserId = Guid.NewGuid(), FollowedUserId = Guid.NewGuid() }
            };
            return Ok(follows);
        }

        [HttpGet("followId:{followId}")]
        public IActionResult GetFollow([FromRoute] Guid followId)
        {
            var follow = new { FollowId = followId, UserId = Guid.NewGuid(), FollowedUserId = Guid.NewGuid() };
            return Ok(follow);
        }

        [HttpGet("userId:{userId}")]
        public IActionResult GetFollowsByUserId([FromRoute] Guid userId)
        {
            var follows = new[]
            {
                new { FollowId = Guid.NewGuid(), UserId = userId, FollowedUserId = Guid.NewGuid() }
            };
            return Ok(follows);
        }

        [HttpPost()]
        public IActionResult FollowUser([FromBody] Guid followedUserId)
        {
            var follow = new { FollowId = Guid.NewGuid(), UserId = Guid.NewGuid(), FollowedUserId = followedUserId };
            return Ok(follow);
        }

        [HttpPost("unfollow")]
        public IActionResult UnfollowUser([FromBody] Guid followedUserId)
        {
            var follow = new { FollowId = Guid.NewGuid(), UserId = Guid.NewGuid(), FollowedUserId = followedUserId };
            return Ok(follow);
        }


    }
}
