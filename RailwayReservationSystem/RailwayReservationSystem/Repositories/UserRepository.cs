using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RailwayReservationSystem.Data;
using RailwayReservationSystem.Models.Domain;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace RailwayReservationSystem.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext obj;

        public UserRepository(DataContext obj)
        {
            this.obj = obj;
        }


        public async Task<User> Authenticate([FromQuery]string email, string password,string role)
        {
            var data = await obj.Users.FirstOrDefaultAsync(x=> x.Email== email && x.Password == password && x.Role==role);

            if(data==null)
            {
                return null;
            }

            return data;
           
            
            
            

           
            
           
        }

     

        public async Task<IEnumerable<User>> GetAllUser()
        {
            var data = await obj.Users.ToListAsync();
            return data;
        }

        public async Task<User> SignUp(User u)
        {
            u.UserId = Guid.NewGuid();
            u.Role = "user";
            //add to database
            await obj.Users.AddAsync(u);
            await obj.SaveChangesAsync();
            return u;

        }



    }
}
