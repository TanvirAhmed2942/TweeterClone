using Microsoft.AspNetCore.Mvc;
using TwitterClone.Application.DTOs;
using TwitterClone.Application.Interfaces;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookmarksController : ControllerBase
    {
        private readonly IBookmarkService _bookmarkService;
        public BookmarksController(IBookmarkService bookmarkService)
        {
            _bookmarkService = bookmarkService;
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<BookmarkDto>), StatusCodes.Status200OK)]
        public IActionResult GetBookmarks([FromQuery] Guid? userId)
        {
            return Ok(_bookmarkService.GetBookmarks(userId));
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BookmarkDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetBookmarkById([FromRoute] Guid id)
        {
            var bookmark = _bookmarkService.GetBookmarkById(id);

            if (bookmark == null)
            {
                return NotFound();
            }
            return Ok(bookmark);
        }

        [HttpPost]
        [ProducesResponseType(typeof(BookmarkDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateBookmark([FromBody] CreateBookmarkDto createBookmarkDto)
        {
            var createdBookmark = _bookmarkService.CreateBookmark(createBookmarkDto);

            if (createdBookmark == null)
            {
                return BadRequest("The user or the tweet does not exist.");
            }
            return CreatedAtAction(nameof(GetBookmarkById), new { id = createdBookmark.Id }, createdBookmark);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteBookmark([FromRoute] Guid id)
        {
            var isDeleted = _bookmarkService.DeleteBookmark(id);

            if (isDeleted == false)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}