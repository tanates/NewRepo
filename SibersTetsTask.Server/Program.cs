using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SibersTetsTask.Server.Context;
using SibersTetsTask.Server.Extensions;
using SibersTetsTask.Server.Interface.Jwt;
using SibersTetsTask.Server.JWT;
using SibersTetsTask.Server.Model.JWT;
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




services.AddScoped<IJwtProvider, JwtProvider>();


var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
