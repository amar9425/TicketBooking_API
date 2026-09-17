using TicketBookingAPI.Models;

namespace TicketBookingAPI.Services.Movies;

public interface IMovieService
{
    Task<List<Movie>> GetMoviesAsync();
}