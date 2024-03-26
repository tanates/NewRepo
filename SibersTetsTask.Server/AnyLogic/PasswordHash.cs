using SibersTetsTask.Server.Interface.Auth;

namespace SibersTetsTask.Server.AnyLogic
{
    public class PasswordHash : IPasswordHash
    {
        public string Generate(string password) =>
            BCrypt.Net.BCrypt.EnhancedHashPassword(password);

        public bool VerifyPassword(string password, string passwordHash) =>
             BCrypt.Net.BCrypt.EnhancedVerify(password, passwordHash);
    }
}
