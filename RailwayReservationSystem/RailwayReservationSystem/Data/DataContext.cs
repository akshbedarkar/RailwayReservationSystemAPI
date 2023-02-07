using Microsoft.EntityFrameworkCore;
using RailwayReservationSystem.Models.Domain;

namespace RailwayReservationSystem.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }

        public DbSet<TrainDetails> TrainInformation { get; set; }
        public DbSet<Reservation> Reservations{ get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Quota> Quotas { get; set; }

        public DbSet<User> Users { get; set; }




    }
}
