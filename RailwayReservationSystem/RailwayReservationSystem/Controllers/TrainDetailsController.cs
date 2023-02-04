using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RailwayReservationSystem.Migrations;
using RailwayReservationSystem.Models.Domain;
using RailwayReservationSystem.Models.DTO;
using RailwayReservationSystem.Repositories;

namespace RailwayReservationSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrainDetailsController : Controller
    {
        private readonly ITrainDetailsRepository obj;
        private readonly IMapper mapper;
        public TrainDetailsController(ITrainDetailsRepository obj,IMapper mapper)
        {
            this.obj = obj;
            this.mapper = mapper;
        }
        [HttpGet]
        [ActionName("GetAllTrain")]
        public async Task <IActionResult> GetAllTrain()
        {
            var traindetails = await obj.GetAllTrains();
            var traindto=mapper.Map<List<Models.DTO.TrainDetails>>(traindetails);
            return Ok(traindto);

        }

        //[HttpPost]
        //public async Task<IActionResult> CreateAddTrain(Addtrainrequest request )
        //{
        //    //request to domain model
        //    var data = new Models.Domain.TrainDetails()
        //    {
        //        TrainName = request.TrainName,
        //        SourceStation=request.SourceStation,
        //        DestinationStation=request.DestinationStation,
        //        SourceDateTime=request.SourceDateTime,
        //        DestinationDateTime=request.DestinationDateTime,
        //    };
        //   data = await obj.AddTrain(data);


        //    //pass data to repo

        //    var traindto = new Models.DTO.TrainDetails()
        //    {
        //        TrainId=data.TrainId,
        //        TrainName = data.TrainName,
        //        SourceStation = data.SourceStation,
        //        DestinationStation = data.DestinationStation,
        //        SourceDateTime = data.SourceDateTime,
        //        DestinationDateTime = data.DestinationDateTime,

        //    };

        //    return CreatedAtAction(nameof(GetAllTrain),new { id=traindto.TrainId},traindto);


        //}


        [HttpGet]
        [Route("destination")]
        public  async Task <IActionResult> GetTrainByDestination(string destination)
        {
           var data=  await obj.GetTrainByDestination(destination);
            if(data==null)
            {
                return NotFound();
            }
           var traindto = mapper.Map<Models.DTO.TrainDetails>(data);
            return Ok(traindto);

        }
    }
}
