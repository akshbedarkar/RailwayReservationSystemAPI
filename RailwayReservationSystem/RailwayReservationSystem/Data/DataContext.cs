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

    }
}
