using Microsoft.EntityFrameworkCore;
using RailwayReservationSystem.Data;
using RailwayReservationSystem.Models.Domain;

namespace RailwayReservationSystem.Repositories
{
    public class QuotaRepository:IQuotaRepository
    {
        private readonly DataContext obj;

        public QuotaRepository(DataContext obj)
        {
            this.obj = obj;
        }

        public async Task<IEnumerable<Quota>> GetAllQuota()
        {
            return await obj.Quotas.ToListAsync();
        }
    }
}
