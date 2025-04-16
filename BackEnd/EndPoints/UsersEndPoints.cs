using BackEnd.Contracts;
using BackEnd.Interfaces.Auth;
using BackEnd.Models;
using BackEnd.Services;
using BackEnd.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.EndPoints;

public static class UsersEndpoints
{
    public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder app)
    {

        app.MapGet("getAllUsers", GetAllUsers);

        return app;
    }



    private static async Task<List<string>> GetAllUsers(UserServices usersService)
    {
     
        return (await usersService.GetAllUsers()).Select(users => users.UserName).ToList();

    }


 

}