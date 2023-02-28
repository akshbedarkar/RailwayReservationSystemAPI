using RailwayReservationSystem.Models.Domain;

namespace RailwayReservationSystem.Repositories
{
    public interface IReservationRepository
    {
        //reservation will be done by user 


        //admin can view the reservations 
        Task<IEnumerable<Reservation>> GetAllReservation();

        //user can we reservation by reservation id 
        Task<Reservation> GetReservartionById(Guid id);

     




        //user should be able to book ticket(single + 6 )
        Task<Reservation> AddReservation(Reservation reserve);


        //public Reservation CancelReservation(string PNRNumber);

        Task<Reservation> DeleteReservation(string number);



    }
}
