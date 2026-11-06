using TwitterClone.Application.DTOs;

namespace TwitterClone.Application.Interfaces
{
    public interface ITokenService
    {
        (string, DateOnly) GetToken(ResponseUserDto? user);
    }
}
