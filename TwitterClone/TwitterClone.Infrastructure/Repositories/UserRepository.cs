using TwitterClone.Application.DTOs;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User>? _users = [];

        public User CreateUser(CreateUserDto user)
        {
            var newUser = new User
            (
                user.FirstName,
                user.LastName,
                user.Email,
                user.Password,
                user.Gender,
                user.Phone
            );
            _users?.Add(newUser);
            Console.WriteLine($"Users count after create: {_users?.Count}");
            return newUser;
        }

        public List<User> FetchAllUsers()
        {
            if (_users == null || _users.Count == 0)
            {
                return [];
            }
            return [.. _users];
        }

        public User? FetchUserById(Guid userId)
        {
            return _users?.SingleOrDefault(u => u.Id == userId);
        }


        public bool IsFoundById(Guid userId)
        {
            return _users?.Any(u => u.Id == userId) ?? false;
        }

        public bool IsEmailExists(string email)
        {
            return _users?.Any(u => u.Email == email) ?? false;
        }

        public User? ModifyUser(Guid userId, UpdateUserDto updateUserDto)
        {
            var existingUser = _users?.SingleOrDefault(u => u.Id == userId);

            if (existingUser == null)
                return null;

            //existingUser.Update(
            //                     dto.FirstName,
            //                     dto.LastName,
            //                     dto.Password,
            //                     dto.Gender,
            //                     dto.Phone
            //                   );

            existingUser.FirstName = updateUserDto?.FirstName ?? existingUser.FirstName;
            existingUser.LastName = updateUserDto?.LastName ?? existingUser.LastName;
            existingUser.Password = updateUserDto?.Password ?? existingUser.Password;
            existingUser.Gender = updateUserDto?.Gender ?? existingUser.Gender;
            existingUser.Phone = updateUserDto?.Phone ?? existingUser.Phone;



            return existingUser;
        }

        public User? PatchUser(Guid userId, PatchUpdateUserDto dto)
        {
            var existingUser = _users?.SingleOrDefault(u => u.Id == userId);

            if (existingUser == null)
                return null;

            if (dto.FirstName != null)
                existingUser.FirstName = dto.FirstName;

            if (dto.LastName != null)
                existingUser.LastName = dto.LastName;

            if (dto.Password != null)
                existingUser.Password = dto.Password;

            if (dto.Gender != null)
                existingUser.Gender = dto.Gender;

            if (dto.Phone != null)
                existingUser.Phone = dto.Phone;

            return existingUser;
        }


        public bool DeleteById(Guid userId)
        {
            var user = _users?.SingleOrDefault(u => u.Id == userId);
            if (user == null)
                return false;
            _users?.Remove(user);
            return true;
        }
    }
}
