using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SibersTetsTask.Server.Model.JWT;
using System.Text;

namespace SibersTetsTask.Server.Extensions
{

    //this is a static class required for extensions of the functional main program.
    public static class ApiExtensions
    {
        //a static method that adds auth to the main program
        public static void AddApiAuthentication (this IServiceCollection services, IOptions<JwtOptions> jwtOptions)
        {
            //Adding the JWT token settings
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.TokenValidationParameters = new()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Value.SecretKey)) //Adding a secret key from model JwtOptions
                };

                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        context.Token = context.Request.Cookies["testy-login"];
                        return Task.CompletedTask;
                    }
                };
            });
        }
    }
}
