using TicketBookingAPI.Models;

namespace TicketBookingAPI.Services.Shows;

public interface IShowService
{
    Task<List<Show>>
        GetShowsByMovieAsync(
            int movieId);
}