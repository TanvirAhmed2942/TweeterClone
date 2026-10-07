using Microsoft.AspNetCore.Mvc;
using TwitterClone.Application.DTOs;
using TwitterClone.Application.Interfaces;


namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userService.GetUsers();
            if (users.Count == 0)
            {
                return NotFound("No users found.");
            }
            return Ok(users);
        }

        [HttpGet("userId:{userId}")]
        public IActionResult GetUserById([FromRoute] Guid userId)
        {
            var userFound = _userService.GetUserById(userId);

            if (userFound == null)
            {
                return NotFound($"User not found: {userId}");
            }

            return Ok(userFound);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserDto createUserDto)
        {

            var userCreated = _userService.CreateUser(createUserDto);
            if (userCreated == null)
            {
                return BadRequest("User creation failed. Please check the provided data.");
            }

            return Ok(userCreated);
        }


        [HttpPut("userId:{userId}")]
        public IActionResult UpdateUser([FromRoute] Guid userId, [FromBody] UpdateUserDto updateUserDto)
        {
            var updatedUser = _userService.UpdateUser(userId, updateUserDto);
            if (updatedUser == null)
            {
                return BadRequest("User update failed. Please check the provided data.");
            }
            return Ok(updatedUser);
        }

        [HttpPatch("userId:{userId}")]

        public IActionResult PatchUser(
            [FromRoute] Guid userId,
            [FromBody] PatchUpdateUserDto patchUpdateUserDto)
        {

            var user = _userService.PatchUser(userId, patchUpdateUserDto);

            if (user == null)
            {
                return NotFound($"User not found: {userId}");
            }

            return Ok(user);
        }

        [HttpDelete("userId:{userId}")]
        public IActionResult DeleteUser([FromRoute] Guid userId)
        {
            var deletedUser = _userService.DeleteUser(userId);

            if (!deletedUser)
            {
                return NotFound($"User not found: {userId}");
            }

            return Ok($"User successfully deleted: {userId}");
        }



    }
}
