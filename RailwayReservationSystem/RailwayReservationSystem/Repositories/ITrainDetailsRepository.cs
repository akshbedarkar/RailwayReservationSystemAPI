using RailwayReservationSystem.Models.Domain;

namespace RailwayReservationSystem.Repositories
{
    public interface ITrainDetailsRepository
    {
        //basic operations performed by admin
        Task<IEnumerable<TrainDetails>>  GetAllTrains();

        Task <TrainDetails> GetTrainByDestination(string destination);
       


    }
}
