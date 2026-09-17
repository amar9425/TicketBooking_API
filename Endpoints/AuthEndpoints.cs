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
    }
}