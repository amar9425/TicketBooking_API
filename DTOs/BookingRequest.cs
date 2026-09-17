namespace TicketBookingAPI.DTOs
{
    public class BookingRequest
    {
        public int UserId { get; set; }

        public int ShowId { get; set; }

        public int Seats { get; set; }
    }
}
