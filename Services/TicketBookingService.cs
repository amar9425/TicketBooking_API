using Microsoft.EntityFrameworkCore;
using TicketBookingAPI.Data;
using TicketBookingAPI.Models;

namespace TicketBookingAPI.Services;

public class TicketBookingService {
    private readonly TicketBookingDbContext _db;  // _db class while used in  multiple places ..

    // here Constructor (same class name ) constructor called automatically when create the object.
    public TicketBookingService(TicketBookingDbContext db)
    {
        _db = db;
    }



    // User Register 
    public async Task<Users> RegisterAsync(Users user)
    {
        _db.Users.Add(user);

        await _db.SaveChangesAsync();

        return user;
    }

    //  User Login 

    public async Task<Users?> LoginAsync(  // Task -> Asynchronus Opeartion returns a result wihle they can't blocked the thread at the time of request and response. and always retuen string type element .
        string userId,
        string password)
    {
        return await _db.Users
            .FirstOrDefaultAsync(a =>   // a-> as a parameters 
                a.UserId == userId &&
                a.Password == password);
    }

    // Get All Movies
    public async Task<List<Movie>> GetMoviesAsync()
    {
        var movies = await _db.Movie
            .AsNoTracking()
            .ToListAsync();

        Console.WriteLine($"Movies Count: {movies.Count}");

        return movies;
    }

    // Get Shows By Movie
    public async Task<List<Show>> GetShowsByMovieAsync(int movieId)
    {
        var shows = await _db.Show
            .Where(show =>
                show.MovieId == movieId &&
                show.AvailableSeats > 0)
            .AsNoTracking()
            .ToListAsync();

        Console.WriteLine(
            $"Shows Count for Movie {movieId}: {shows.Count}");

        return shows;
    }


    // Book Seats

    public async Task<bool> BookSeatsAsync(
        int userId,
        int showId,
        int seats)
    {
        var show = await _db.Show
            .FirstOrDefaultAsync(a => a.Id == showId);

        if (show == null)
            return false;

        if (show.AvailableSeats < seats)
            return false;

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

    // User Booking History

    public async Task<List<Booking>> GetBookingsByUserAsync(
        int userId)
    {
        return await _db.Booking
            .Where(a => a.UserId == userId)
            .ToListAsync();

    }
}



