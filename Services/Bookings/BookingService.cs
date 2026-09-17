using Microsoft.EntityFrameworkCore;
using TicketBookingAPI.Data;
using TicketBookingAPI.Models;

namespace TicketBookingAPI.Services.Bookings;

public class BookingService : IBookingService
{
    private readonly TicketBookingDbContext _db;

    public BookingService(
        TicketBookingDbContext db)
    {
        _db = db;
    }

    public async Task<bool> BookSeatsAsync(
        int userId,
        int showId,
        int seats)
    {
        var show = await _db.Show
            .FirstOrDefaultAsync(
                x => x.Id == showId);

        if (show == null)
        {
            return false;
        }

        // Booking closes 1 hour before show

        if (DateTime.Now >=
            show.ShowDateTime.AddHours(-1))
        {
            return false;
        }

        if (seats <= 0)
        {
            return false;
        }

        if (show.AvailableSeats < seats)
        {
            return false;
        }

        var booking = new Booking
        {
            UserId = userId,
            ShowId = showId,
            SeatsBooked = seats,
            BookingDate = DateTime.Now
        };

        _db.Booking.Add(booking);

        show.AvailableSeats -= seats;

        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<List<Booking>>
        GetBookingsByUserAsync(
            int userId)
    {
        return await _db.Booking
            .Where(x =>
                x.UserId == userId)
            .ToListAsync();
    }
}