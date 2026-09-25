namespace TicketBookingAPI.Helpers;

public static class HeaderHelper
{
    public static string GetUserId(
        HttpContext context)
    {
        var userId =
            context.Request
                .Headers["UserId"]
                .FirstOrDefault();

        if (string.IsNullOrEmpty(userId))
        {
            throw new Exception(
                "UserId Header Missing");
        }

        return userId;
    }
}