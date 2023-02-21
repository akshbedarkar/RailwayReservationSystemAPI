using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
        //[Authorize(Roles ="admin")]
        //[Authorize(Roles = "user")]
        public async Task<IActionResult> GetAllReservations()
        {
            //fetch data from database-domain
            var data =  await obj.GetAllReservation();

            //convert to dto 
            var reservationdto = map.Map<List<Models.DTO.Reservations>>(data);

            //response back 200
            return Ok(reservationdto);


        }

        [HttpGet]
        [Route("{id:guid}")]
        //[Authorize(Roles = "admin")]
        //[Authorize(Roles = "user")]
        public   async  Task<IActionResult> GetAllReservationById(Guid id )
        {
            //get data from domain
            var reservationfromdomain = await obj.GetReservartionById(id);

            //convert domin object to DTO (using automapper)
            var reservationdto = map.Map<Models.DTO.Reservations>(reservationfromdomain);

            //pass back the response(200)
            return Ok(reservationdto);


        }


        [HttpPost]
        //[Authorize(Roles = "user")]
        public async Task<IActionResult> AddReservation([FromBody] Models.DTO.AddReservationRequest request)
        {
            //dto to domain
            var data = new Models.Domain.Reservation
            {
                ReservationName = request.ReservationName,
                ReservationGender = request.ReservationGender,
                ReservationAddress = request.ReservationAddress,
                ReservationDate = request.ReservationDate,
                UserId = request.UserId,
                TrainId= request.TrainId,
                QuotaId=request.QuotaId



            };
            //domain to database
            data = await obj.AddReservation(data);

            //domain to dto
            var reservationdto = new Models.DTO.Reservations
            {
                ReservationId=data.ReservationId,
                ReservationName=data.ReservationName,
                ReservationAddress=data.ReservationAddress,
                ReservationDate=data.ReservationDate,
                ReservationGender=data.ReservationGender,
                UserId=data.UserId,
                QuotaId=data.QuotaId,
                TrainId=data.TrainId

            };


            //pass data back 
            return Ok(reservationdto);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        //[Authorize(Roles = "User")]
        public async Task<IActionResult> CancelReservation(Guid id)
        {
            var data = await obj.CancelReservation(id);

            if(data==null)
            {
                return NotFound();
            }
            //pass back to user 
            var cancelreservationdto = map.Map<Models.DTO.Reservations>(data);
            return Ok(cancelreservationdto);


           

        }


       

    }
}
