using SibersTetsTask.Server.Model.ModelDTO.UserDTO;

namespace SibersTetsTask.Server.Interface.Jwt
{
    public interface IJwtProvider
    {
        public string GeneratToken(EmployeeDTO employee);
    }
}