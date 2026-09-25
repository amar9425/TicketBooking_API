using Microsoft.EntityFrameworkCore;
using TicketBookingAPI.Data;
using TicketBookingAPI.Models;

namespace TicketBookingAPI.Services.Auth;

public class AuthService : IAuthService
{
    private readonly TicketBookingDbContext _db;

    public AuthService(
        TicketBookingDbContext db)
    {
        _db = db;
    }

    public async Task<Users?> LoginAsync(
        string userId,
        string password)
    {
        return await _db.Users
            .FirstOrDefaultAsync(x =>
                x.UserId == userId &&
                x.Password == password);
    }

    public async Task<bool> RegisterAsync(
        Users user)
    {
        bool exists =
            await _db.Users.AnyAsync(x =>
                x.UserId == user.UserId);

        if (exists)
        {
            return false;
        }

        _db.Users.Add(user);

        await _db.SaveChangesAsync();

        return true;
    }
}