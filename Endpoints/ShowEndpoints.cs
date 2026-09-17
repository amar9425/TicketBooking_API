using TicketBookingAPI.Services;

namespace TicketBookingAPI.Endpoints;

public static class ShowEndpoints
{
    public static void MapShowEndpoints(
        this WebApplication app)
    {
        app.MapGet("/api/shows/movie/{movieId}",

        async (
            int movieId,
            TicketBookingService service) =>
        {
            var shows =
                await service.GetShowsByMovieAsync(
                    movieId);

            return Results.Ok(shows);
        });
    }
}