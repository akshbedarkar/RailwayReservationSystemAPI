using RailwayReservationSystem.Models.Domain;

namespace RailwayReservationSystem.Repositories
{
    public interface ITokenHandler
    {
        Task<string> GenrateToken(User u);
    }
}
