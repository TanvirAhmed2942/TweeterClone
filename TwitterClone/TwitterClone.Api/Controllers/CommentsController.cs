using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetComments()
        {
            var comments = new[]
            {
                new { CommentId = Guid.NewGuid(), Content = "This is a comment." },
                new { CommentId = Guid.NewGuid(), Content = "Another comment here." },
                new { CommentId = Guid.NewGuid(), Content = "Yet another comment." }
            };
            return Ok(comments);
        }
        [HttpGet("commentId:{commentId}")]
        public IActionResult GetComment([FromRoute] Guid commentId)
        {
            var comment = new { CommentId = commentId, Content = "This is a sample comment." };
            return Ok(comment);
        }
        [HttpGet("userId:{userId}")]
        public IActionResult GetCommentsByUserId([FromRoute] Guid userId)
        {
            var comments = new[]
            {
                new { CommentId = Guid.NewGuid(), Content = "This is a comment." },
                new { CommentId = Guid.NewGuid(), Content = "Another comment here." },
                new { CommentId = Guid.NewGuid(), Content = "Yet another comment." }
            };
            return Ok(comments);
        }
        [HttpPost]
        public IActionResult PostComment([FromBody] string content)
        {
            var comment = new { CommentId = Guid.NewGuid(), Content = content };
            return Ok(comment);
        }
        [HttpPut("commentId:{commentId}")]
        public IActionResult UpdateComment([FromRoute] Guid commentId, [FromBody] string content)
        {
            var comment = new { CommentId = commentId, Content = content };
            return Ok(comment);
        }
        [HttpDelete("commentId:{commentId}")]
        public IActionResult DeleteComment([FromRoute] Guid commentId)
        {
            var comment = new { CommentId = commentId, Content = "This comment has been deleted." };
            return Ok(comment);
        }
    }
}
