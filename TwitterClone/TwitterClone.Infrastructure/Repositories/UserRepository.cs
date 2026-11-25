using TwitterClone.Application.DTOs;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Persistence;

namespace TwitterClone.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TwitterCloneDbContext _dbContext;


        public UserRepository(TwitterCloneDbContext dbContext)
        {
            _dbContext = dbContext;
        }

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
            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
            return newUser;
        }

        public List<User> FetchAllUsers()
        {
            return _dbContext.Users.ToList();
        }

        public User? FetchUserById(Guid userId)
        {
            return _dbContext.Users.SingleOrDefault(u => u.Id == userId);
        }

        public User? FetchUserByEmail(string email)
        {
            return _dbContext.Users.SingleOrDefault(u => u.Email == email);
        }


        public User? IsFoundById(Guid userId)
        {
            return _dbContext.Users.SingleOrDefault(u => u.Id == userId);
        }

        public bool IsEmailExists(string email)
        {
            return _dbContext.Users.Any(u => u.Email == email);
        }

        public User? ModifyUser(Guid userId, UpdateUserDto updateUserDto)
        {
            var existingUser = _dbContext.Users.SingleOrDefault(u => u.Id == userId);

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
            existingUser.PasswordHash = updateUserDto?.Password ?? existingUser.PasswordHash;
            existingUser.Gender = updateUserDto?.Gender ?? existingUser.Gender;
            existingUser.Phone = updateUserDto?.Phone ?? existingUser.Phone;



            return existingUser;
        }

        public User? PatchUser(Guid userId, PatchUpdateUserDto dto)
        {
            var existingUser = _dbContext.Users.SingleOrDefault(u => u.Id == userId);

            if (existingUser == null)
                return null;

            if (dto.FirstName != null)
                existingUser.FirstName = dto.FirstName;

            if (dto.LastName != null)
                existingUser.LastName = dto.LastName;

            if (dto.Password != null)
                existingUser.PasswordHash = dto.Password;

            if (dto.Gender != null)
                existingUser.Gender = dto.Gender;

            if (dto.Phone != null)
                existingUser.Phone = dto.Phone;

            return existingUser;
        }


        public bool DeleteById(Guid userId)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == userId);
            if (user == null)
                return false;
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
            return true;
        }

        public void AddUserRole(UserRole userRole)
        {
            _dbContext.UserRoles.Add(userRole);
            _dbContext.SaveChanges();
        }

        public void RemoveUserRole(UserRole userRole)
        {
            _dbContext.UserRoles.Remove(userRole);
            _dbContext.SaveChanges();
        }
    }
}
