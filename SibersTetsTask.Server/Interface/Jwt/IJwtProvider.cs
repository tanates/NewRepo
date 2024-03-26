using SibersTetsTask.Server.Model.User;

namespace SibersTetsTask.Server.Interface.Jwt
{
    public interface IJwtProvider
    {
        public string GeneratToken(Employee employee);
    }
}