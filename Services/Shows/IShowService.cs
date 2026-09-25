using TicketBookingAPI.Models;
using System;
using System.Threading.Tasks;


namespace TicketBookingAPI.Services.Shows;

public interface IShowService
{
    Task<Show?> GetShowByIdAsync(
        int showId);

    Task<List<Show>> GetShowsByMovieAsync(
        int movieId);

    Task<List<Show>> GetShowsByDateAsync(
        DateTime date);
}