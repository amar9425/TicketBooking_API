using Microsoft.EntityFrameworkCore;
using TicketBookingAPI.Models;

namespace TicketBookingAPI.Data
{
    public class TicketBookingDbContext : DbContext
    {
        public TicketBookingDbContext(
            DbContextOptions<TicketBookingDbContext> options)
            : base(options)
        {

        }

        public DbSet<Users> Users { get; set; }

        public DbSet<Movie> Movie { get; set; }


        public DbSet<Show> Show { get; set; }


        public DbSet<Booking> Booking { get; set; }

    }
}