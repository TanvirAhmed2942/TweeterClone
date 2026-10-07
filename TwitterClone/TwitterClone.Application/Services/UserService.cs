using TwitterClone.Application.DTOs;
using TwitterClone.Application.Interfaces;


namespace TwitterClone.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ResponseUserDto? CreateUser(CreateUserDto createUserDto)
        {
            if (createUserDto == null
               || string.IsNullOrEmpty(createUserDto.FirstName)
               || string.IsNullOrEmpty(createUserDto.LastName)
               || string.IsNullOrEmpty(createUserDto.Email)
               || string.IsNullOrEmpty(createUserDto.Password)
               || string.IsNullOrEmpty(createUserDto.Gender)
               || string.IsNullOrEmpty(createUserDto.Phone))
            {
                return null;
            }

            bool existingEmail = _userRepository.IsEmailExists(createUserDto.Email);

            if (existingEmail)
            {
                return null;
            }

            var newUser = new CreateUserDto
            {
                FirstName = createUserDto.FirstName,
                LastName = createUserDto.LastName,
                Email = createUserDto.Email,
                Password = createUserDto.Password,
                Gender = createUserDto.Gender,
                Phone = createUserDto.Phone
            };

            var userCreated = _userRepository.CreateUser(createUserDto);
            if (userCreated == null)
            {
                return null;
            }
            return new ResponseUserDto
            {
                Id = userCreated.Id,
                Email = userCreated.Email,
                Name = userCreated.FirstName + " " + userCreated.LastName,
                Gender = userCreated.Gender,
                Phone = userCreated.Phone
            };



        }

        public bool DeleteUser(Guid userId)
        {
            var deletedUser = _userRepository.DeleteById(userId);
            if (deletedUser == null)
            {
                return false;
            }
            return true;
        }

        public ResponseUserDto? GetUserById(Guid userId)
        {
            var userFound = _userRepository.FetchUserById(userId);
            if (userFound == null)
            {
                return null;
            }

            return new ResponseUserDto
            {
                Id = userFound.Id,
                Name = userFound.FirstName + " " + userFound.LastName,
                Email = userFound.Email,
                Gender = userFound.Gender,
                Phone = userFound.Phone
            };


        }

        public List<ResponseUserDto>? GetUsers()
        {
            var users = _userRepository.FetchAllUsers();
            if (users == null || users.Count == 0)
            {
                return null;
            }
            return users.Select(u => new ResponseUserDto
            {
                Id = u.Id,
                Name = u.FirstName + " " + u.LastName,
                Email = u.Email,
                Gender = u.Gender,
                Phone = u.Phone
            }).ToList();
        }

        public ResponseUserDto PatchUser(Guid userId, PatchUpdateUserDto patchUpdateUserDto)
        {
            if (patchUpdateUserDto == null)
            {
                return null;
            }

            if (string.IsNullOrEmpty(patchUpdateUserDto.FirstName)
                && string.IsNullOrEmpty(patchUpdateUserDto.LastName)
                && string.IsNullOrEmpty(patchUpdateUserDto.Password)
                && string.IsNullOrEmpty(patchUpdateUserDto.Gender)
                && string.IsNullOrEmpty(patchUpdateUserDto.Phone))
            {
                return null;
            }

            var patchedUser = _userRepository.PatchUser(userId, patchUpdateUserDto);

            return new ResponseUserDto
            {
                Id = patchedUser.Id,
                Name = patchedUser.FirstName + " " + patchedUser.LastName,
                Email = patchedUser.Email,
                Gender = patchedUser.Gender,
                Phone = patchedUser.Phone
            };
        }

        public ResponseUserDto UpdateUser(Guid userId, UpdateUserDto updateUserDto)
        {
            if (updateUserDto == null
               || string.IsNullOrEmpty(updateUserDto.FirstName)
               || string.IsNullOrEmpty(updateUserDto.LastName)
               || string.IsNullOrEmpty(updateUserDto.Password)
               || string.IsNullOrEmpty(updateUserDto.Gender)
               || string.IsNullOrEmpty(updateUserDto.Phone)
               || _userRepository.ModifyUser(userId, updateUserDto) == null)
            {
                return null;
            }

            var updatedUser = _userRepository.ModifyUser(userId, updateUserDto);
            return new ResponseUserDto
            {
                Id = updatedUser.Id,
                Name = updatedUser.FirstName + " " + updatedUser.LastName,
                Email = updatedUser.Email,
                Gender = updatedUser.Gender,
                Phone = updatedUser.Phone
            };
        }
    }
}
