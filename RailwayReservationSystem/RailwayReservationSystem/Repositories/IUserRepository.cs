using RailwayReservationSystem.Models.Domain;

namespace RailwayReservationSystem.Repositories
{
    public interface IUserRepository
    {
        Task<User> Authenticate(string email, string password,string role);

        Task<User> SignUp(User u );

        Task<IEnumerable<User>> GetAllUser();

   





    }
}
