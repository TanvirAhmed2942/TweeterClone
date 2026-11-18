using Microsoft.AspNetCore.Identity;
using TwitterClone.Application.DTOs;
using TwitterClone.Application.Interfaces;

namespace TwitterClone.Infrastructure.Auth
{
    public class PasswordHasher : IPasswordHasher
    {
        private PasswordHasher<ResponseUserDto> _passwordHasher = new PasswordHasher<ResponseUserDto>();
        public string Hash(ResponseUserDto? userDto, string password)
        {
            if (userDto == null)
            {
                throw new ArgumentNullException(nameof(userDto));
            }
            return _passwordHasher.HashPassword(userDto, password);
        }

        public bool VerifyPassword(ResponseUserDto? userDto, string password, string passwordHash)
        {
            if (userDto == null)
            {
                return false;
            }

            var result = _passwordHasher.VerifyHashedPassword(userDto, passwordHash, password);

            if (result == PasswordVerificationResult.Success)
            {
                return true;
            }
            return false;
        }
    }
}
