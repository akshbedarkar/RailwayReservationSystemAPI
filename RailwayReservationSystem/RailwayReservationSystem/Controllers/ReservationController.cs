using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RailwayReservationSystem.Repositories;

namespace RailwayReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationRepository obj;
        private readonly IMapper map;

        public ReservationController(IReservationRepository obj,IMapper map)
        {
            this.obj = obj;
            this.map = map;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReservations()
        {
            //fetch data from database-domain
            var data =  await obj.GetAllReservation();

            //convert to dto 
            var reservationdto = map.Map<List<Models.DTO.Reservations>>(data);

            //response back 200
            return Ok(reservationdto);


        }

       

    }
}
