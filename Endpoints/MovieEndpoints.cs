using TicketBookingAPI.Services;

namespace TicketBookingAPI.Endpoints;

public static class MovieEndpoints
{
    public static void MapMovieEndpoints(this WebApplication app)
    {
        app.MapGet("/api/movies",
        async (TicketBookingService service) =>
        {
            var movies = await service.GetMoviesAsync();

            return Results.Ok(movies);
        });
    }
}