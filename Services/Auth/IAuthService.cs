using TicketBookingAPI.Models;

namespace TicketBookingAPI.Services.Auth;

public interface IAuthService
{
    Task<Users?> LoginAsync(
        string userId,
        string password);

    Task<bool> RegisterAsync(
        Users user);
}