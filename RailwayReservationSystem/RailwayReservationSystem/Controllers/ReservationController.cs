using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RailwayReservationSystem.Repositories;

namespace RailwayReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ReservationController : ControllerBase
    {
        /* The reservation controller will make the reservation 
         * Delete reservations based on the PNR number  and  
         * Show all the reservations */


        #region Reservation 

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

        [HttpGet]
        [Route("{id:guid}")]
       
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
        [EnableCors("_allowspecificorigin")]
        public async Task<IActionResult> AddReservation([FromBody] Models.DTO.AddReservationRequest request)
        {
            //dto to domain
            var data = new Models.Domain.Reservation
            {
                ReservationName = request.ReservationName,
                ReservationGender = request.ReservationGender,
                ReservationAddress = request.ReservationAddress,
                ReservationDate = request.ReservationDate,
                Quota=request.Quota,
                UserId = request.UserId,
                TrainName = request.TrainName,
               



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
                Quota=data.Quota,
                TrainName = data.TrainName

            };


            //pass data back 
            return Ok(reservationdto);
        }

        

        [HttpDelete]
        [Route("number")]

        [EnableCors("_allowspecificorigin")]
        public async Task<IActionResult> DeleteReservation(string number)
        {
            var data = await obj.DeleteReservation(number);
            if (data == null)
            {
                return NotFound();

            }
           
            return Ok(data);
        }



        #endregion 

    }
}
