using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SibersTetsTask.Server.AnyLogic;
using SibersTetsTask.Server.Context;
using SibersTetsTask.Server.Extensions;
using SibersTetsTask.Server.Interface.Auth;
using SibersTetsTask.Server.Interface.IEmployee;
using SibersTetsTask.Server.Interface.Jwt;
using SibersTetsTask.Server.Interface.ProjectInt;
using SibersTetsTask.Server.JWT;
using SibersTetsTask.Server.Model.ModelDTO.JWT;
using SibersTetsTask.Server.Repository;
using SibersTetsTask.Server.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();


services.AddScoped<IPasswordHash ,PasswordHash>();
services.AddScoped<IAuthRepository, AuthRepository>();
services.AddScoped<IEmployeeRepository , EmployeeRepository>();
services.AddScoped<IProjectRepository  ,ProjectRepository>();
services.AddScoped<IProjectTaskRepository , ProjectTaskRepository>();
services.AddScoped<TaskProjectServices>();
services.AddScoped<ProjectsServisec>();
services.AddScoped<EmployeesServisec>();
services.AddScoped<IJwtProvider, JwtProvider>();


services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("https://localhost:5173")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
        });
});

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");
app.UseHttpsRedirection();

app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
