using TicketBookingAPI.Services.Movies;

namespace TicketBookingAPI.Endpoints;

public static class MovieEndpoints
{
    public static void MapMovieEndpoints(
        this WebApplication app)
    {
        app.MapGet("/api/movies",
        async (
            IMovieService service) =>
        {
            var movies =
                await service.GetMoviesAsync();

            return Results.Ok(movies);
        });
    }
}