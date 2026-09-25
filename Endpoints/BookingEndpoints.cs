using TicketBookingAPI.DTOs;
using TicketBookingAPI.Models;
<<<<<<< HEAD
using TicketBookingAPI.Services;
=======
>>>>>>> d17e09942ae38a48299c28b5d999ae14707f4770
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

<<<<<<< HEAD
        // find a booking on the behalf of userId.

=======
        // Booking History
>>>>>>> d17e09942ae38a48299c28b5d999ae14707f4770
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