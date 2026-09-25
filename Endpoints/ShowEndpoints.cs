using TicketBookingAPI.Services.Shows;

namespace TicketBookingAPI.Endpoints;

public static class ShowEndpoints
{
    public static void MapShowEndpoints(
        this WebApplication app)
    {
        app.MapGet(
            "/api/shows/movie/{movieId}",
            async (
                int movieId,
                IShowService service) =>
            {
                var shows =
                    await service.GetShowsByMovieAsync(
                        movieId);

                return Results.Ok(shows);
            }
        );
<<<<<<< HEAD
        app.MapGet("/api/shows/{showId}",
    async (
        int showId,
        IShowService service) =>
    {
        var show =
            await service.GetShowByIdAsync(
                showId
            );

        if (show == null)
        {
            return Results.NotFound();
        }

        return Results.Ok(show);
    }
);

        // Shows available for particular date 

        app.MapGet(
     "/api/shows/date/{date}",
     async (
         DateTime date,
         IShowService service) =>
     {
         var shows =
             await service
                 .GetShowsByDateAsync(
                     date);

         return Results.Ok(shows);
     });
=======
>>>>>>> d17e09942ae38a48299c28b5d999ae14707f4770
    }
}

