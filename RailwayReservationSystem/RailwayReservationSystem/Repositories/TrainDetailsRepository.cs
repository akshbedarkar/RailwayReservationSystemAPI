using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using RailwayReservationSystem.Data;
using RailwayReservationSystem.Models.Domain;

namespace RailwayReservationSystem.Repositories
{
    public class TrainDetailsRepository : ITrainDetailsRepository
    {
        private readonly DataContext _obj;

        public TrainDetailsRepository(DataContext obj)
        {
            _obj = obj;
        }

      

        public  async Task<IEnumerable<TrainDetails>> GetAllTrains()
        {
            return await _obj.TrainInformation.ToListAsync();

        }

    }
}
