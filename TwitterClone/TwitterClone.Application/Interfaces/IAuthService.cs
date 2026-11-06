using TwitterClone.Application.DTOs;

namespace TwitterClone.Application.Interfaces
{
    public interface IAuthService
    {
        AuthResponseDto? Login(LoginDto loginDto);
    }
}
