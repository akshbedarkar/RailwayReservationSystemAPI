using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using RailwayReservationSystem.Data;
using RailwayReservationSystem.Models.Domain;
using System.Numerics;

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
            reserve.ReservationId = Guid.NewGuid();
            Guid guid = Guid.NewGuid();
            BigInteger big = new BigInteger(guid.ToByteArray());
            var bigstr = big.ToString();
            var str = bigstr.Replace("-", string.Empty);
            var pnr = str.ToString().Substring(0, 10);
            
            reserve.PNRNumber = pnr;
            
           
            //add to database
            await obj.Reservations.AddAsync(reserve);
            await obj.SaveChangesAsync();
            return reserve;
           


        }

        public async Task<Reservation> DeleteReservation(string number)
        {
            //var deletereservation = await obj.Reservations.FindAsync(number);
            var deletereservation = await obj.Reservations.FirstOrDefaultAsync(x => x.PNRNumber == number);
            if (deletereservation  == null)
            {
                return null;
            }
            obj.Reservations.Remove(deletereservation);
            await obj.SaveChangesAsync();
            return deletereservation ;

        }

        public async Task<IEnumerable<Reservation>> GetAllReservation()
        {
            var data = await obj.Reservations
                .Include(x=>x.User)
                .ToListAsync();
            return data;
        }
        public async Task<Reservation> GetReservartionById(Guid id)
        {
            var data = await obj.Reservations
                 .Include(x => x.User)
                 .FirstOrDefaultAsync(x => x.ReservationId == id);

            return data;


        }




        
    }
}
