using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SibersTetsTask.Server.Interface.Jwt;
using SibersTetsTask.Server.Model.ModelDTO.JWT;
using SibersTetsTask.Server.Model.ModelDTO.UserDTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SibersTetsTask.Server.JWT
{
    public class JwtProvider : IJwtProvider
    {
        private readonly JwtOptions _options;
        public JwtProvider(IOptions<JwtOptions> options)
        {
            _options = options.Value;
        }


        public string GeneratToken(EmployeeDTO Employee)
        {
            Claim[] calims = [new("userId", Employee.Id.ToString())];

            var signing = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)), SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken
                (
                   claims: calims,
                   signingCredentials: signing,
                   expires: DateTime.UtcNow.AddHours(_options.ExpitesHours));
            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenValue;
        }
    }
}
