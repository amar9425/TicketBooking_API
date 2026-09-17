using TicketBookingAPI.Models;
using TicketBookingAPI.Services;

namespace TicketBookingAPI.Endpoints;

public static class BookingEndpoints
{
    public static void MapBookingEndpoints(
        this WebApplication app)
    {
        app.MapPost("/api/bookings",
        async (
            BookingRequest request,
            TicketBookingService service) =>
        {
            var result =
                await service.BookSeatsAsync(
                    request.UserId,
                    request.ShowId,
                    request.Seats);

            if (!result)
            {
                return Results.BadRequest(
                    "Seats Not Available");
            }

            return Results.Ok(
                "Booking Successful");
        });

        app.MapGet("/api/users/{userId}/bookings",
        async (
            int userId,
            TicketBookingService service) =>
        {
            var bookings =
                await service.GetBookingsByUserAsync(
                    userId);

            return Results.Ok(bookings);
        });
    }
}
