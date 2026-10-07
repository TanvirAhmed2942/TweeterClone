using Microsoft.AspNetCore.Mvc;
using TwitterClone.Application.DTOs;
using TwitterClone.Application.Interfaces;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetsController : ControllerBase
    {
        private readonly ITweetService _tweetService;

        public TweetsController(ITweetService tweetService)
        {
            _tweetService = tweetService;
        }



        [HttpGet]
        public IActionResult GetTweets()
        {


            var allTweets = _tweetService.GetAllTweets();

            if (allTweets == null)
            {
                return NotFound("No tweets found.");
            }

            return Ok(allTweets);
        }

        [HttpGet("tweetId:{tweetId}")]
        public IActionResult GetTweetById([FromRoute] Guid tweetId)
        {
            var tweet = _tweetService.FetchTweetById(tweetId);
            if (tweet == null)
            {
                return NotFound("Tweet not found.");
            }
            return Ok(tweet);
        }

        [HttpGet("userId:{userId}")]
        public IActionResult GetTweetsByUserId([FromRoute] Guid userId)
        {
            var tweetByUser = _tweetService.FetchTweetsByUserId(userId);
            if (tweetByUser == null)
            {
                return NotFound($"Tweets not found for this user: {userId}");
            }
            return Ok(tweetByUser);
        }

        [HttpPost]
        public IActionResult PostTweet([FromBody] CreateTweetDto createTweetDto)
        {
            var addedTweet = _tweetService.AddTweet(createTweetDto);
            if (addedTweet == null)
            {
                return BadRequest("Failed to add tweet.");
            }
            return Ok(addedTweet);
        }

        [HttpPut("tweetId:{tweetId}")]
        public IActionResult UpdateTweet([FromRoute] Guid tweetId, [FromBody] UpdateTweetDto updateDto)
        {

            var modifiedTweet = _tweetService.ModifyContent(tweetId, updateDto.Content);
            if (modifiedTweet == null)
            {
                return NotFound("Tweet not found.");
            }

            return Ok(modifiedTweet);
        }

        //[HttpPatch("tweetId:{tweetId}")]
        //public IActionResult PatchTweet([FromRoute] Guid tweetId, [FromBody] string content)
        //{
        //    var tweet = new { TweetId = tweetId, Content = content };
        //    return Ok(tweet);
        //}

        [HttpDelete("tweetId:{tweetId}")]
        public IActionResult DeleteTweet([FromRoute] Guid tweetId)
        {
            var deletedTweet = _tweetService.DeleteById(tweetId);

            if (deletedTweet == null)
            {
                return NotFound();
            }
            return Ok(deletedTweet);
        }












        //private readonly IConfiguration _configuration;
        //private readonly HttpClient _httpClient;


        //public TweetsController(IConfiguration configuration,HttpClient httpClient)
        //{
        //    _configuration = configuration;
        //    _httpClient = httpClient;
        //}

        //var maxLength = _configuration.GetValue<string>("TwitterSettings:MaxTweetLength");
        //string appName = _configuration.GetValue<string>("App:AppName");
        //return Ok($"Max Tweet Lenght: {maxLength} \nApp Name: {appName}");

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
