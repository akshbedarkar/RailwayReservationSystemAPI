using RailwayReservationSystem.Models.Domain;

namespace RailwayReservationSystem.Repositories
{
    public interface ITrainDetailsRepository
    {
      //user and admin can view the traindetails
        Task<IEnumerable<TrainDetails>>  GetAllTrains();

        //user can search by location
        Task <TrainDetails> GetTrainByDestination(string destination);

        //admin can add the train details
        Task<TrainDetails> AddTrain(TrainDetails train);

        //admin can update the train details
        Task<TrainDetails> UpdateTrain(Guid id,TrainDetails t);

        //admin can delete the train details
        Task<TrainDetails> DeleteTrainById(Guid id);


    }
}
