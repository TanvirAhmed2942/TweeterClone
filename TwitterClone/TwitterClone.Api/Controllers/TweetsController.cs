

using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetsController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;


        public TweetsController(IConfiguration configuration,HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }

        [HttpGet]
        public IActionResult GetTweets()
        {
            var maxLength = _configuration.GetValue<string>("TwitterSettings:MaxTweetLength");
            string appName = _configuration.GetValue<string>("App:AppName");
            return Ok($"Max Tweet Lenght: {maxLength} \nApp Name: {appName}");
        }

        [HttpGet("tweetId:{tweetId}")]
        public IActionResult GetTweet([FromRoute] Guid tweetId)
        {
            var tweet = new { TweetId = tweetId, Content = "This is a sample tweet." };
            return Ok(tweet);
        }

        [HttpGet("userId:{userId}")]
        public IActionResult GetTweetsByUserId([FromRoute] Guid userId)
        {
            var tweets = new[]
            {
                new { TweetId = Guid.NewGuid(), Content = "This is a tweet." },
                new { TweetId = Guid.NewGuid(), Content = "Another tweet here." },
                new { TweetId = Guid.NewGuid(), Content = "Yet another tweet." }
            };
            return Ok(tweets);
        }

        [HttpPost]
        public IActionResult PostTweet([FromBody] string content)
        {
            var tweet = new { TweetId = Guid.NewGuid(), Content = content };
            return Ok(tweet);
        }

        [HttpPut("tweetId:{tweetId}")]
        public IActionResult UpdateTweet([FromRoute] Guid tweetId, [FromBody] string content)
        {
            var tweet = new { TweetId = tweetId, Content = content };
            return Ok(tweet);
        }

        [HttpPatch("tweetId:{tweetId}")]
        public IActionResult PatchTweet([FromRoute] Guid tweetId, [FromBody] string content)
        {
            var tweet = new { TweetId = tweetId, Content = content };
            return Ok(tweet);
        }

        [HttpDelete("tweetId:{tweetId}")]
        public IActionResult DeleteTweet([FromRoute] Guid tweetId)
        {
            var tweet = new { TweetId = tweetId, Content = "This tweet has been deleted." };
            return Ok(tweet);
        }


        //[HttpGet]
        //public async Task<IActionResult> GetAge()
        //{
        //    var url = _configuration.GetValue<string>(
        //        "AgePrediction:ApiURL"
        //    ) + "?name=John";

        //    var response = await _httpClient.GetAsync(url);

        //    var json = await response.Content.ReadAsStringAsync();

        //    Console.WriteLine(json);

        //    return Ok(json);
        //}
    }
}
