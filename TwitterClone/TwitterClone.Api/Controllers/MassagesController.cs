using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MassagesController : ControllerBase
    {
        

        [HttpGet]
       
        public IActionResult GetMassages()
        {
            var massages = new[]
            {
                new { MassageId = Guid.NewGuid(), Content = "Hello, how are you?" },
                new { MassageId = Guid.NewGuid(), Content = "Don't forget our meeting tomorrow." },
                new { MassageId = Guid.NewGuid(), Content = "Happy Birthday!" }
            };
            return Ok(massages);
        }

        [HttpGet("massageId:{massageId}")]
        public IActionResult GetMassage([FromRoute] Guid massageId)
        {
            var massage = new { MassageId = massageId, Content = "This is a sample massage." };
            return Ok(massage);
        }

        [HttpGet("userId:{userId}")]
        public IActionResult GetMassagesByUserId([FromRoute] Guid userId)
        {
            var massages = new[]
            {
                new { MassageId = Guid.NewGuid(), Content = "Hello, how are you?" },
                new { MassageId = Guid.NewGuid(), Content = "Don't forget our meeting tomorrow." },
                new { MassageId = Guid.NewGuid(), Content = "Happy Birthday!" }
            };
            return Ok(massages);
        }

        [HttpPost]
        public IActionResult SendMassage([FromBody] string massage)
        {

            return Ok(new { Message = "Massage sent successfully!", Content = massage });
        }

        [HttpPut("massageId:{massageId}")]
        public IActionResult UpdateMassage([FromRoute] Guid massageId, [FromBody] string content)
        {
            var massage = new { MassageId = massageId, Content = content };
            return Ok(massage);
        }

        [HttpDelete("massageId:{massageId}")]
        public IActionResult DeleteMassage([FromRoute] Guid massageId)
        {
            var massage = new { MassageId = massageId, Content = "This massage has been deleted." };
            return Ok(massage);
        }
    }
}
