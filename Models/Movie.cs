using System.ComponentModel.DataAnnotations;

namespace TicketBookingAPI.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public String MovieName { get; set; } = string.Empty;
        public String Description { get; set; } = string.Empty;

    }
}
