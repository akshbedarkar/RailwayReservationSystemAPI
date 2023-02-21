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
            //train.TrainId = Guid.NewGuid();
            await _obj.AddAsync(train);
            await _obj.SaveChangesAsync();
            return train;
           
        }

        public async Task<TrainDetails> DeleteTrainById(Guid id)
        {
            var deletetrain = await _obj.TrainInformation.FindAsync(id);
            if(deletetrain==null)
            {
                return null;
            }
            _obj.TrainInformation.Remove(deletetrain);
            await _obj.SaveChangesAsync();
            return deletetrain;

            
        }

        public  async Task<IEnumerable<TrainDetails>> GetAllTrains()
        {
            return await _obj.TrainInformation.ToListAsync();

        }

        public  async Task<TrainDetails> GetTrainByDestination(string destination)
        {
            return await _obj.TrainInformation.FirstOrDefaultAsync(x=>x.DestinationStation==destination);
            
        }

        public async Task<TrainDetails> GetTrainById(Guid id)
        {
            return await _obj.TrainInformation.FirstOrDefaultAsync(x => x.TrainId == id);
        }

        public async Task<TrainDetails> UpdateTrain(Guid id,TrainDetails t)
        {
            var traindetails = await _obj.TrainInformation.FindAsync(id);
            if (traindetails == null)
            {
                return null;
            }

            traindetails.TrainName = t.TrainName;
            traindetails.SourceStation = t.SourceStation;
            traindetails.DestinationStation = t.DestinationStation;
            traindetails.SourceDateTime = t.SourceDateTime;
            traindetails.DestinationDateTime = t.DestinationDateTime;

            
            await _obj.SaveChangesAsync();
            return traindetails; 
        }
    }
}
