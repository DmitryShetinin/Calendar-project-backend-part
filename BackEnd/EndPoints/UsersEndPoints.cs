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
        app.MapPost("register", Register);
        app.MapPost("login", Login);
        app.MapPost("createEvent", CreateEvent);
        app.MapPost("createCalendar", CreateCalendar);
        app.MapGet("getAllUsers", GetAllUsers);
        app.MapGet("getAllCalendars", GetAllCalendars);
        app.MapGet("getAllEvents", GetAllEvents);

        app.MapPut("updateEvents", UpdateEvents);

        app.MapDelete("deleteEvent", DeleteEvent);
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



    private static async Task<List<string>> GetAllUsers(UserServices usersService)
    {
     
        return (await usersService.GetAllUsers()).Select(users => users.UserName).ToList();

    }


    private static async Task<IResult> CreateEvent(Event data, EventService eventService)
    {
       
        if (data == null)
        {
            return Results.NotFound();
        }
        await eventService.CreateEvent(data);

		return Results.Ok();
	}


    private static async Task<Guid> CreateCalendar([FromBody] CalendarRequest request, EventService eventService)
    {
        if (request.Name == null)
        {
            throw new Exception("Error");
        }

        return await eventService.CreateCalendar(request.Name, request.UserId);
   
    }


    private static async Task<Dictionary<Guid, string>> GetAllCalendars(Guid UserId, EventService eventService)
    {
        return await eventService.GetAllCalendars(UserId);    
    }

    private static async Task<List<Event>> GetAllEvents(EventService eventService)
    {
        return await eventService.GetAllEvents();
    }


    private static async Task UpdateEvents(EventService eventService, Event eventUpdate)
    {

        if (eventUpdate == null)
        {
            throw new Exception("Error");
        }

        await eventService.UpdateEvents(eventUpdate);
    }


    private static async Task DeleteEvent(EventService eventService, Guid IdEvent)
    {

        if (IdEvent == null)
        {
            throw new Exception("Error");
        }

        await eventService.DeleteEvent(IdEvent);
    }


}