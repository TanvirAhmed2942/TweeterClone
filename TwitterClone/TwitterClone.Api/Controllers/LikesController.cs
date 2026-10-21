using Microsoft.AspNetCore.Mvc;
using TwitterClone.Application.DTOs;
using TwitterClone.Application.Interfaces;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikesController : ControllerBase
    {
        private readonly ILikeService _likeService;
        public LikesController(ILikeService likeService)
        {
            _likeService = likeService;
        }


        [HttpGet]
        [ProducesResponseType(typeof(List<LikeDto>), StatusCodes.Status200OK)]
        public IActionResult GetLikes([FromQuery] Guid? userId, [FromQuery] Guid? tweetId)
        {
            return Ok(_likeService.GetLikes(userId, tweetId));
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(LikeDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetLikeById([FromRoute] Guid id)
        {
            var like = _likeService.GetLikeById(id);

            if (like == null)
            {
                return NotFound();
            }
            return Ok(like);

        }

        [HttpPost]
        [ProducesResponseType(typeof(LikeDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateLike([FromBody] CreateLikeDto createLikeDto)
        {
            var createdLike = _likeService.CreateLike(createLikeDto);
            if (createdLike == null)
            {
                return BadRequest("The user or the tweet does not exist, or the tweet cannot be liked.");
            }
            return CreatedAtAction(nameof(GetLikeById), new { id = createdLike.Id }, createdLike);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteLike([FromRoute] Guid id)
        {
            var isDeleted = _likeService.DeleteLike(id);

            if (isDeleted == false)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}