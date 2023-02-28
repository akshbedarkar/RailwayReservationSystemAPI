using RailwayReservationSystem.Models.Domain;

namespace RailwayReservationSystem.Repositories
{
    public interface IQuotaRepository
    {
        Task<IEnumerable<Quota>> GetAllQuota();
    }
}
