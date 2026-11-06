using TwitterClone.Application.Interfaces;

namespace TwitterClone.Infrastructure.Auth
{
    public class PasswordHasher : IPasswordHasher
    {
        public bool VerifyPassword(string password, string passwordHash)
        {
            //verify logic
            return true;
        }
    }
}
