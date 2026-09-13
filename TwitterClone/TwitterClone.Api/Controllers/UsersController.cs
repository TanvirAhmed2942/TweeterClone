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

    }
}
