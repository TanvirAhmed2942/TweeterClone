using Microsoft.AspNetCore.Mvc;
using TwitterClone.Application.DTOs;
using TwitterClone.Application.Interfaces;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RetweetsController : ControllerBase
    {
        private readonly IRetweetService _retweetService;

        public RetweetsController(
            IRetweetService retweetService)
        {
            _retweetService = retweetService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<RetweetDto>), StatusCodes.Status200OK)]
        public IActionResult GetRetweets([FromQuery] Guid? userId, [FromQuery] Guid? tweetId)
        {
            return Ok(_retweetService.GetRetweets(userId, tweetId));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RetweetDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetRetweetById([FromRoute] Guid id)
        {
            var retweet = _retweetService.GetRetweetById(id);

            if (retweet == null)
            {
                return NoContent();
            }
            return Ok(retweet);
        }
        [HttpPost]
        [ProducesResponseType(typeof(RetweetDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateRetweet([FromBody] CreateRetweetDto createRetweetDto)
        {
            var createdRetweet = _retweetService.CreateRetweet(createRetweetDto);

            if (createdRetweet == null)
            {
                return BadRequest("The user or the tweet does not exist.");
            }
            return CreatedAtAction(nameof(GetRetweetById), new { id = createdRetweet.Id }, createdRetweet);
        }

        [HttpPut("{id}")]

        [ProducesResponseType(typeof(RetweetDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateRetweet([FromRoute] Guid id, [FromBody] UpdateRetweetDto updateRetweetDto)
        {

            var retweet = _retweetService.UpdateRetweet(id, updateRetweetDto);

            if (retweet == null)
            {
                return NotFound();
            }
            return Ok(retweet);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteRetweet([FromRoute] Guid id)
        {

            var isDeleted = _retweetService.DeleteRetweet(id);

            if (isDeleted == false)
            {

                return NotFound();
            }
            return NoContent();
        }

    }

}
