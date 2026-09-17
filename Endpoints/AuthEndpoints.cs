using TicketBookingAPI.Models;
using TicketBookingAPI.Services;

namespace TicketBookingAPI.Endpoints;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this WebApplication app)
    {
        app.MapGet("/api/test", () => 
        {
            return Results.Ok(new
            {
                Message = "API Testing"

            });
        });

        app.MapPost("/api/register",
        async (Users user, TicketBookingService service) =>
        {
            var result = await service.RegisterAsync(user);

            return Results.Ok(result);
        });

        app.MapPost("/api/login",
async (
    LoginRequest request,
    TicketBookingService service) =>
{
    var user = await service.LoginAsync(
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