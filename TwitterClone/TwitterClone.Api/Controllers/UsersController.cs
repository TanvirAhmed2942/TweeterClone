using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Api.Data;
using TwitterClone.Api.DTOs;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        public UsersController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userRepository.FetchAllUsers();

            if (users.Count() == 0)
            {
                return NoContent();
            }

            return Ok(users);

        }

        [HttpGet("userId:{userId}")]
        public IActionResult GetUserById([FromRoute] Guid userId)
        {
            var userFound = _userRepository.FetchUserById(userId);

            if (userFound == null)
            {
                return NotFound($"User not found: {userId}");
            }

            return Ok(userFound);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserDto createUserDto)
        {

            if (createUserDto == null
                || string.IsNullOrEmpty(createUserDto.FirstName)
                || string.IsNullOrEmpty(createUserDto.LastName)
                || string.IsNullOrEmpty(createUserDto.Email)
                || string.IsNullOrEmpty(createUserDto.Password)
                || string.IsNullOrEmpty(createUserDto.Gender)
                || string.IsNullOrEmpty(createUserDto.Phone))
            {
                return BadRequest($"User data is required. {nameof(createUserDto)} cannot be null or empty.");
            }

            bool existingEmail = _userRepository.IsEmailExists(createUserDto.Email);

            if (existingEmail)
            {
                return BadRequest($"{createUserDto.Email} already Exists");
            }

            var newUser = new User
            (
                createUserDto.FirstName,
                createUserDto.LastName,
                createUserDto.Email,
                createUserDto.Password,
                createUserDto.Gender,
                createUserDto.Phone
            );

            var userCreated = _userRepository.AddUser(newUser);

            return Ok(userCreated);
        }


        [HttpPut("userId:{userId}")]
        public IActionResult UpdateUser([FromRoute] Guid userId, [FromBody] UpdateUserDto updateUserDto)
        {
            if (updateUserDto == null
                || string.IsNullOrEmpty(updateUserDto.FirstName)
                || string.IsNullOrEmpty(updateUserDto.LastName)
                || string.IsNullOrEmpty(updateUserDto.Password)
                || string.IsNullOrEmpty(updateUserDto.Gender)
                || string.IsNullOrEmpty(updateUserDto.Phone))
            {
                return BadRequest($"User data is required. {nameof(updateUserDto)} cannot be null or empty.");
            }


            if (_userRepository.ModifyUser(
                                                    userId,
                                                    updateUserDto.FirstName!,
                                                    updateUserDto.LastName!,
                                                    updateUserDto.Password!,
                                                    updateUserDto.Gender!,
                                                    updateUserDto.Phone!
                                                 ) == null)
            {
                return NotFound($"User not found: {userId}");
            }

            return Ok(_userRepository.ModifyUser(
                                                    userId,
                                                    updateUserDto.FirstName!,
                                                    updateUserDto.LastName!,
                                                    updateUserDto.Password!,
                                                    updateUserDto.Gender!,
                                                    updateUserDto.Phone!
                                                 ));
        }

        [HttpPatch("userId:{userId}")]

        public IActionResult PatchUser(
    [FromRoute] Guid userId,
    [FromBody] PatchUpdateUserDto patchUpdateUserDto)
        {
            if (patchUpdateUserDto == null)
            {
                return BadRequest("Update data cannot be null.");
            }

            if (string.IsNullOrEmpty(patchUpdateUserDto.FirstName)
                && string.IsNullOrEmpty(patchUpdateUserDto.LastName)
                && string.IsNullOrEmpty(patchUpdateUserDto.Password)
                && string.IsNullOrEmpty(patchUpdateUserDto.Gender)
                && string.IsNullOrEmpty(patchUpdateUserDto.Phone))
            {
                return BadRequest("At least one field is required to update.");
            }

            var user = _userRepository.PatchUser(userId, patchUpdateUserDto);

            if (user == null)
            {
                return NotFound($"User not found: {userId}");
            }

            return Ok(user);
        }

        [HttpDelete("userId:{userId}")]
        public IActionResult DeleteUser([FromRoute] Guid userId)
        {
            var deletedUser = _userRepository.DeleteById(userId);

            if (deletedUser == null)
            {
                return NotFound($"User not found: {userId}");
            }

            return Ok($"User successfully deleted: {userId}");
        }



    }
}
