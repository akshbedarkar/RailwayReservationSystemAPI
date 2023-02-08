using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using RailwayReservationSystem.Data;
using RailwayReservationSystem.Models.Domain;

namespace RailwayReservationSystem.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly DataContext obj;

        public ReservationRepository(DataContext obj)
        {
            this.obj = obj;
        }

        public async Task<Reservation> AddReservation(Reservation reserve)
        {
            //guid for reservation
            reserve.ReservationId = Guid.NewGuid();
            //add to database
            await obj.Reservations.AddAsync(reserve);
            await obj.SaveChangesAsync();
            return reserve;
           


        }

        public async Task<Reservation> CancelReservation(Guid id)
        {
            var data = await obj.Reservations.FindAsync(id);
            if(data==null)
            {
                return null;
            }

            obj.Reservations.Remove(data);
            await obj.SaveChangesAsync();
            return data;

            
        }

        public async Task<IEnumerable<Reservation>> GetAllReservation()
        {
            var data = await obj.Reservations
                .Include(x=>x.User)
                .Include(x=>x.quota)
                .Include(x=>x.TrainDetails)
                .ToListAsync();
            return data;
        }

        public async Task<Reservation> GetReservartionById(Guid id)
        {
            var data = await obj.Reservations
                 .Include(x => x.User)
                 .Include(x => x.quota)
                 .Include(x => x.TrainDetails)
                 .FirstOrDefaultAsync(x => x.ReservationId == id);

            return data;


        }
    }
}
