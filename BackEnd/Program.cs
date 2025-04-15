using BackEnd;
using BackEnd.EndPoints;
using BackEnd.Extensions;
using BackEnd.Infrastructure;
using BackEnd.Interfaces.Auth;
using BackEnd.Services;

using BackEnd.Core.Interfaces.Repositories;
using BackEnd.Application.Services;
using BackEnd.Persistence.Repositories;
using BackEnd.Persistence;
using BackEnd.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

// Настройка порта
builder.WebHost.UseUrls("http://localhost:5051");

services.AddApiAuthentication(configuration);
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddScoped<IEventRepository, EventRepository>();
services.AddScoped<IUserRepository, UsersRepository>();


services.AddScoped<IJwtProvider, JwtProvider>();
services.AddScoped<IPasswordHasher, PasswordHasher>();


services.AddAutoMapper(typeof(DataBaseMappings));
services.AddScoped<AuthService>();
services.AddScoped<UserServices>();
services.AddScoped<EventService>();
 



services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("LearningDbContext"));
});

services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Настройка Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = "swagger"; // Путь /swagger/index.html
    });
}

app.UseCors();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.MapUsersEndpoints();

app.Run();