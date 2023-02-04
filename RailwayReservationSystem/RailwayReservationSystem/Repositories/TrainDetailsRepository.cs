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

        public async Task<TrainDetails> AddTrain(TrainDetails train)
        {
            train.TrainId = Guid.NewGuid();
            await _obj.AddAsync(train);
            await _obj.SaveChangesAsync();
            return train;
           
        }

        public  async Task<IEnumerable<TrainDetails>> GetAllTrains()
        {
            return await _obj.TrainInformation.ToListAsync();

        }

        public  async Task<TrainDetails> GetTrainByDestination(string destination)
        {
            return await _obj.TrainInformation.FirstOrDefaultAsync(x=>x.DestinationStation==destination);
            
        }
    }
}
