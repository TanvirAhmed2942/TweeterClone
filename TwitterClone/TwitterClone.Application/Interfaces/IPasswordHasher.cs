using TwitterClone.Application.DTOs;

namespace TwitterClone.Application.Interfaces
{
    public interface IPasswordHasher
    {
        bool VerifyPassword(ResponseUserDto? userDto, string password, string passwordHash);

        string Hash(ResponseUserDto? userDto, string password);
    }
}
