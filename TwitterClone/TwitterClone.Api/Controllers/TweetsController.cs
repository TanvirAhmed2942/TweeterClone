using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetsController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        

        public TweetsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetTweets()
        {
            var maxLength = _configuration.GetValue<string>("TwitterSettings:MaxTweetLength");
            string appName = _configuration.GetValue<string>("App:AppName");
            return Ok( $"Max Tweet Lenght: {maxLength} \nApp Name: { appName}");
        }
    }
}
