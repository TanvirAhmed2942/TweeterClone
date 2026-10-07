using TwitterClone.Application.DTOs;


namespace TwitterClone.Application.Interfaces
{
    public interface IUserService
    {
        List<ResponseUserDto>? GetUsers();
        ResponseUserDto? GetUserById(Guid userId);

        ResponseUserDto? CreateUser(CreateUserDto createUserDto);

        ResponseUserDto UpdateUser(Guid userId, UpdateUserDto updateUserDto);
        ResponseUserDto PatchUser(Guid userId, PatchUpdateUserDto patchUpdateUserDto);
        bool DeleteUser(Guid userId);
    }
}
