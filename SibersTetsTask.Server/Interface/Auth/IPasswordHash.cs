namespace SibersTetsTask.Server.Interface.Auth
{
    public interface IPasswordHash
    {
        string Generate(string password);
        bool VerifyPassword(string password, string passwordHash);
    }
}
