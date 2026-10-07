using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class NotificationsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetNotifications()
        {
            var notifications = new List<object>
            {
                new
                {
                    notificationId = Guid.NewGuid(),
                    message = "You have a new follower!"
                },
                new
                {
                    notificationId = Guid.NewGuid(),
                    message = "Your tweet has been liked!"
                },
                new
                {
                    notificationId = Guid.NewGuid(),
                    message = "You have a new mention!"
                }
            };
            return Ok(notifications);
        }


        [HttpGet("notificationId:{notificationId}")]
        public IActionResult GetNotification([FromRoute] Guid notificationId)
        {
            var notification = new
            {
                notificationId = notificationId,
                message = "This is a sample notification."
            };
            return Ok(notification);
        }


        [HttpGet("userId:{userId}")]
        public IActionResult GetNotificationsByUserId([FromRoute] Guid userId)
        {
            var notifications = new List<object>
            {
                new
                {
                    notificationId = Guid.NewGuid(),
                    message = "You have a new follower!"
                },
                new
                {
                    notificationId = Guid.NewGuid(),
                    message = "Your tweet has been liked!"
                },
                new
                {
                    notificationId = Guid.NewGuid(),
                    message = "You have a new mention!"
                }
            };
            return Ok(notifications);
        }

        [HttpPut("notificationId:{notificationId}")]
        public IActionResult UpdateNotification([FromRoute] Guid notificationId, [FromBody] string message)
        {
            var notification = new
            {
                notificationId = notificationId,
                message = message
            };  
            return Ok(notification);
        }

        [HttpDelete("notificationId:{notificationId}")]
        public IActionResult DeleteNotification([FromRoute] Guid notificationId)
        {
            var notification = new
            {
                notificationId = notificationId,
                message = "This notification has been deleted."
            };
            return Ok(notification.message);
        }
    }
}
