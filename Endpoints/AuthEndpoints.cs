using TicketBookingAPI.DTOs;
using TicketBookingAPI.Models;
using TicketBookingAPI.Services.Auth;

namespace TicketBookingAPI.Endpoints;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(
        this WebApplication app)
    {
        app.MapGet("/api/test", () =>
        {
            return Results.Ok("API Running");
        });

        app.MapPost("/api/register",
<<<<<<< HEAD
 async (
     Users user,
     IAuthService service) =>
 {
     if (string.IsNullOrWhiteSpace(user.UserId))
     {
         return Results.BadRequest(
             "UserId is required.");
     }

     if (user.UserId.Length < 4 ||
         user.UserId.Length > 10)
     {
         return Results.BadRequest(
             "UserId must be between 4 and 20 characters.");
     }

     if (string.IsNullOrWhiteSpace(user.Name))
     {
         return Results.BadRequest(
             "Name is required.");
     }

     if (user.Name.Length < 2 ||
         user.Name.Length > 20)
     {
         return Results.BadRequest(
             "Name must be between 2 and 20 characters.");
     }

     if (string.IsNullOrWhiteSpace(user.Password))
     {
         return Results.BadRequest(
             "Password is required.");
     }

     if (user.Password.Length < 6)
     {
         return Results.BadRequest(
             "Password must be at least 6 characters.");
     }

     var result =
         await service.RegisterAsync(user);

     if (!result)
     {
         return Results.BadRequest(
             "UserId already exists.");
     }

     return Results.Ok(
         "Registration Successful");
 });

        app.MapPost("/api/login",
 async (
     LoginRequest request,
     IAuthService service) =>
 {
     if (string.IsNullOrWhiteSpace(request.UserId))
     {
         return Results.BadRequest("UserId is required.");
     }

     if (request.UserId.Length < 4 ||
         request.UserId.Length > 20)
     {
         return Results.BadRequest(
             "UserId must be between 4 and 20 characters.");
     }

     if (string.IsNullOrWhiteSpace(request.Password))
     {
         return Results.BadRequest(
             "Password is required.");
     }

     var user =
         await service.LoginAsync(
             request.UserId,
             request.Password);

     if (user == null)
     {
         return Results.BadRequest(
             "Invalid Credentials");
     }

     return Results.Ok(user);
 });
=======
        async (
            Users user,
            IAuthService service) =>
        {
            var result =
                await service.RegisterAsync(user);

            if (!result)
            {
                return Results.BadRequest(
                    "UserId Already Exists");
            }

            return Results.Ok(
                "Registration Successful");
        });

        app.MapPost("/api/login",
        async (
            LoginRequest request,
            IAuthService service) =>
        {
            var user =
                await service.LoginAsync(
                    request.UserId,
                    request.Password);

            if (user == null)
            {
                return Results.BadRequest(
                    "Invalid Credentials");
            }

            return Results.Ok(user);
        });
>>>>>>> d17e09942ae38a48299c28b5d999ae14707f4770
    }
}