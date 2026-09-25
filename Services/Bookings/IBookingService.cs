using TicketBookingAPI.Models;

namespace TicketBookingAPI.Services.Bookings;

public interface IBookingService
{
    Task<bool> BookSeatsAsync(
<<<<<<< HEAD
         int userId,
        int showId,
        int seats);
=======
        int userId,
        int showId,
        int seats);

>>>>>>> d17e09942ae38a48299c28b5d999ae14707f4770
    Task<List<Booking>>
        GetBookingsByUserAsync(
            int userId);
}