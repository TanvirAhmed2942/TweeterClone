using Microsoft.AspNetCore.Mvc;
using TwitterClone.Api.Data;
using TwitterClone.Api.DTOs;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetsController : ControllerBase
    {
        public readonly TweetRepository _tweetRepository;

        public TweetsController(TweetRepository tweetRepository)
        {
            _tweetRepository = tweetRepository;
        }

        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;


        //public TweetsController(IConfiguration configuration,HttpClient httpClient)
        //{
        //    _configuration = configuration;
        //    _httpClient = httpClient;
        //}

        [HttpGet]
        public IActionResult GetTweets()
        {
            //var maxLength = _configuration.GetValue<string>("TwitterSettings:MaxTweetLength");
            //string appName = _configuration.GetValue<string>("App:AppName");
            //return Ok($"Max Tweet Lenght: {maxLength} \nApp Name: {appName}");

            var allTweets = _tweetRepository.GetAllTweets();

            if (!allTweets.Any())
            {
                return NotFound("No tweets found.");
            }

            return Ok(allTweets);
        }

        [HttpGet("tweetId:{tweetId}")]
        public IActionResult GetTweet([FromRoute] Guid tweetId)
        {
            var tweet = _tweetRepository.FetchTweetById(tweetId);
            if (tweet == null)
            {
                return NotFound("Tweet not found.");
            }
            return Ok(tweet);
        }

        [HttpGet("userId:{userId}")]
        public IActionResult GetTweetsByUserId([FromRoute] Guid userId)
        {
            var tweetByUser = _tweetRepository.FetchTweetsByUserId(userId);
            if(tweetByUser == null)
            {
                return NotFound($"Tweets not found for this user: {userId}");
            }
            return Ok(tweetByUser);
        }

        [HttpPost]
        public IActionResult PostTweet([FromBody] CreateTweetDto createTweetDto)
        {
            if(createTweetDto == null || string.IsNullOrWhiteSpace(createTweetDto.Content))
            {
                return BadRequest("Invalid tweet data.");
            }

            var tweet = new Tweet(createTweetDto.UserId, createTweetDto.Content);
            var addedTweet = _tweetRepository.AddTweet(tweet);
            return Ok(addedTweet);
        }

        [HttpPut("tweetId:{tweetId}")]
        public IActionResult UpdateTweet([FromRoute] Guid tweetId, [FromBody] UpdateTweetDto updateDto)
        {
            Console.WriteLine("sss");
            bool found = _tweetRepository.IsFoundById(tweetId);

            if (!found)
            {
                return NotFound();
            }


            var modifiedTweet = _tweetRepository.ModifyContent(tweetId, updateDto.Content);
            

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
            var deletedTweet = _tweetRepository.DeleteById(tweetId);

            if (deletedTweet == null)
            {
                return NotFound();
            }
            return Ok(deletedTweet);
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
