using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]

        public IActionResult GetUser()
        {
            var users = new List<object>
        {
            new
            {
                userId = Guid.NewGuid(),
                userName = "Tanvir Ahmed Swapnil"
            },
            new
            {
                userId = Guid.NewGuid(),
                userName = "Ali Hayder Shuvo"
            },
            new
            {
                userId = Guid.NewGuid(),
                userName = "Shomirul Hayder Shourav"
            }
        };
            return Ok(users);

        }

        [HttpGet("userId:{userId}")]
        public IActionResult GetUserById([FromRoute] Guid userId)
        {
            var user = new
            {
                userId = userId,
                userName = "Sample User"
            };
            return Ok(user);
        }

        [HttpPost]
        public IActionResult PostUser([FromBody] string userName)
        {
            var user = new
            {
                userId = Guid.NewGuid(),
                userName = userName
            };
            return Ok(user);
        }


        [HttpPut("userId:{userId}")]
        public IActionResult UpdateUser([FromRoute] Guid userId, [FromBody] string userName)
        {
            var user = new
            {
                userId = userId,
                userName = userName
            };
            return Ok(user);
        }

        [HttpPatch("userId:{userId}/phoneNumber")]
        public IActionResult PatchUser([FromRoute] Guid userId, [FromBody] string phoneNumber)
        {
            var user = new
            {
                userId = userId,
                phoneNumber = phoneNumber
            };
            return Ok(user);
        }

        [HttpDelete("userId:{userId}")]
        public IActionResult DeleteUser([FromRoute] Guid userId)
        {
            var user = new
            {
                userId = userId,
                userName = "This user has been deleted."
            };
            return Ok(user);
        }



    }
}
