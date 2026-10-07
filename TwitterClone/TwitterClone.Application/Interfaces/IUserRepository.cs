using TwitterClone.Application.DTOs;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Interfaces
{
    public interface IUserRepository
    {
        User CreateUser(CreateUserDto user);
        List<User>? FetchAllUsers();
        User? FetchUserById(Guid userId);

        bool IsFoundById(Guid userId);

        bool IsEmailExists(string email);

        User? ModifyUser(Guid userId, UpdateUserDto dto);

        User? PatchUser(Guid userId, PatchUpdateUserDto dto);

        User? DeleteById(Guid userId);
    }
}
