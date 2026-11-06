using TwitterClone.Application.DTOs;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Interfaces
{
    public interface IUserRepository
    {
        User CreateUser(CreateUserDto user);
        List<User> FetchAllUsers();
        User? FetchUserById(Guid userId);
        User? FetchUserByEmail(string email);

        User? IsFoundById(Guid userId);

        bool IsEmailExists(string email);

        User? ModifyUser(Guid userId, UpdateUserDto updateUserDto);

        User? PatchUser(Guid userId, PatchUpdateUserDto dto);

        bool DeleteById(Guid userId);
    }
}
