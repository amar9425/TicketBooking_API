using Microsoft.EntityFrameworkCore;
using TicketBookingAPI.Data;
using TicketBookingAPI.Models;

namespace TicketBookingAPI.Services.Movies;

public class MovieService : IMovieService
{
    private readonly TicketBookingDbContext _db;

    public MovieService(
        TicketBookingDbContext db)
    {
        _db = db;
    }

    public async Task<List<Movie>>
        GetMoviesAsync()
    {
        return await _db.Movie
            .AsNoTracking()
            .ToListAsync();
    }
}