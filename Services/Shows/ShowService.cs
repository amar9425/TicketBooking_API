using Microsoft.EntityFrameworkCore;
using TicketBookingAPI.Data;
using TicketBookingAPI.Models;

namespace TicketBookingAPI.Services.Shows;

public class ShowService : IShowService
{
    private readonly TicketBookingDbContext _db;

    public ShowService(
        TicketBookingDbContext db)
    {
        _db = db;
    }

    public async Task<List<Show>>
        GetShowsByMovieAsync(
            int movieId)
    {
        return await _db.Show
            .Where(x =>
                x.MovieId == movieId &&
                x.AvailableSeats > 0)
            .ToListAsync();
    }
}