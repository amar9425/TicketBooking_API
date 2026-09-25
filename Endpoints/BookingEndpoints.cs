using TicketBookingAPI.DTOs;
using TicketBookingAPI.Models;
using TicketBookingAPI.Services;
using TicketBookingAPI.Services.Bookings;

namespace TicketBookingAPI.Endpoints;

public static class BookingEndpoints
{
    public static void MapBookingEndpoints(
        this WebApplication app)
    {
        app.MapPost("/api/bookings",
        async (
            BookingRequest request,
            IBookingService service) =>
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

        // find a booking on the behalf of userId.

        app.MapGet("/api/users/{userId}/bookings",
        async (
            int userId,
            IBookingService service) =>
        {
            var bookings =
                await service.GetBookingsByUserAsync(
                    userId);

            return Results.Ok(bookings);
        });
    }
}
