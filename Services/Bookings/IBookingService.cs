using TicketBookingAPI.Models;

namespace TicketBookingAPI.Services.Bookings;

public interface IBookingService
{
    Task<bool> BookSeatsAsync(
         int userId,
        int showId,
        int seats);
    Task<List<Booking>>
        GetBookingsByUserAsync(
            int userId);
}