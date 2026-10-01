using TwitterClone.Api.DTOs;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Data
{
    public class UserRepository
    {
        private List<User> _users = new List<User>();

        public User AddUser(User user)
        {
            _users.Add(user);
            return user;
        }

        public IEnumerable<User> FetchAllUsers()
        {
            return _users;
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
                                string firstName,
                                string lastName,
                                string password,
                                string gender,
                                string phone)
        {
            var existingUser = _users.SingleOrDefault(u => u.Id == userId);

            if (existingUser == null)
                return null;

            existingUser.Update(
                                 firstName,
                                 lastName,
                                 password,
                                 gender,
                                 phone
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
