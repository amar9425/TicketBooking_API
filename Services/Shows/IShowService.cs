using TicketBookingAPI.Models;
<<<<<<< HEAD
using System;
using System.Threading.Tasks;

=======
>>>>>>> d17e09942ae38a48299c28b5d999ae14707f4770

namespace TicketBookingAPI.Services.Shows;

public interface IShowService
{
<<<<<<< HEAD
    Task<Show?> GetShowByIdAsync(
        int showId);

    Task<List<Show>> GetShowsByMovieAsync(
        int movieId);

    Task<List<Show>> GetShowsByDateAsync(
        DateTime date);
=======
    Task<List<Show>>
        GetShowsByMovieAsync(
            int movieId);
>>>>>>> d17e09942ae38a48299c28b5d999ae14707f4770
}