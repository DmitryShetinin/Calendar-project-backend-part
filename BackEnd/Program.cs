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

// ��������� �����
builder.WebHost.UseUrls("http://+:5051");
 
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


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("LearningDbContext")),
    ServiceLifetime.Scoped   
);


 

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






// ��������� Swagger

 
app.UseSwagger();
app.UseSwaggerUI();
 

app.UseCors();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.MapEventsEndpoints(); 
app.MapUsersEndpoints();
app.MapAuthEndpoints(); 
app.Run();