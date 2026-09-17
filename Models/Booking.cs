using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations;

namespace TicketBookingAPI.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ShowId { get; set; }
        public int  SeatsBooked { get; set; }
        public DateTime BookingDate { get; set; }


    }
}
