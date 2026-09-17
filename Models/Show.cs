
using System.ComponentModel.DataAnnotations;

namespace TicketBookingAPI.Models
{
    public class Show
    {
        [Key]
        public int Id { get; set; }
        public int MovieId { get; set; }
        public DateTime ShowDateTime { get; set; }
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }




    }
}
