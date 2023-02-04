using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RailwayReservationSystem.Models.Domain;
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
        public async Task<IActionResult> GetAllTrain()
        {
            var traindetails = obj.GetAllTrains();
            var traindto=mapper.Map<List<Models.DTO.TrainDetails>>(traindetails);
            return Ok(traindto);

        }
    }
}
