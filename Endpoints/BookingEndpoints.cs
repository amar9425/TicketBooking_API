using TicketBookingAPI.DTOs;
using TicketBookingAPI.Models;
using TicketBookingAPI.Services.Bookings;

namespace TicketBookingAPI.Endpoints;

public static class BookingEndpoints
{
    public static void MapBookingEndpoints(
        this WebApplication app)
    {
        // Book Ticket
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
                    "Booking Closed / Seats Not Available");
            }

            return Results.Ok(
                "Booking Successful");
        });

        // Booking History
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