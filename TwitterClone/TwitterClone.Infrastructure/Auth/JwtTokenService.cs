using TwitterClone.Application.DTOs;
using TwitterClone.Application.Interfaces;

namespace TwitterClone.Infrastructure.Auth
{
    public class JwtTokenService : ITokenService
    {
        public (string, DateOnly) GetToken(ResponseUserDto? user)
        {
            return (string.Empty, DateOnly.MinValue);
        }
    }
}
