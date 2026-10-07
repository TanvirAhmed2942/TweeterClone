using TwitterClone.Application.DTOs;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Data
{
    public class UserRepository : IUserRepository
    {
        private List<User>? _users = new List<User>();

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
            _users.Add(newUser);
            Console.WriteLine($"Users count after create: {_users.Count}");
            return newUser;
        }

        public List<User>? FetchAllUsers()
        {
            return _users.ToList();
        }

        public User? FetchUserById(Guid userId)
        {
            return _users.SingleOrDefault(u => u.Id == userId);
        }


        public bool IsFoundById(Guid userId)
        {
            return _users.Any(u => u.Id == userId);
        }

        public bool IsEmailExists(string email)
        {
            return _users.Any(u => u.Email == email);
        }

        public User? ModifyUser(
                                Guid userId,
                                UpdateUserDto dto)
        {
            var existingUser = _users.SingleOrDefault(u => u.Id == userId);

            if (existingUser == null)
                return null;

            existingUser.Update(
                                 dto.FirstName,
                                 dto.LastName,
                                 dto.Password,
                                 dto.Gender,
                                 dto.Phone
                               );

            return existingUser;
        }

        public User? PatchUser(Guid userId, PatchUpdateUserDto dto)
        {
            var existingUser = _users.SingleOrDefault(u => u.Id == userId);

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


        public User? DeleteById(Guid userId)
        {
            var user = _users.SingleOrDefault(u => u.Id == userId);
            if (user == null)
                return null;
            _users.Remove(user);
            return user;
        }
    }
}
