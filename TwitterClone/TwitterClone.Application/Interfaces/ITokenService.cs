using TwitterClone.Application.DTOs;

namespace TwitterClone.Application.Interfaces
{
    public interface ITokenService
    {
        (string, DateTime) GetToken(ResponseUserDto? user);
    }
}
