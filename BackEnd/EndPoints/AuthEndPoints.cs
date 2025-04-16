using BackEnd.Contracts;
using BackEnd.Interfaces.Auth;
using BackEnd.Models;
using BackEnd.Services;
using BackEnd.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.EndPoints;

public static class AuthEndPoints
{
    public static IEndpointRouteBuilder MapAuthEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("register", Register);
        app.MapPost("login", Login);
     

        return app;
    }

    private static async Task<IResult> Register(
    [FromBody] RegisterUserRequest request,
    [FromServices] AuthService authService) // Добавьте [FromServices]
    {
        await authService.RegisterAsync(request.UserName, request.Email, request.Password);
        return Results.Ok();
    }

    private static async Task<Guid> Login(
    [FromBody] LoginUserRequest request,
    [FromServices] AuthService usersService,
    HttpContext context)
    {
        var id = await usersService.LoginAsync(request.Email, request.Password);
        return id;
    }


 



}