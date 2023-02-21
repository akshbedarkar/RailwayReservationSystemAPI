using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RailwayReservationSystem.Repositories;

namespace RailwayReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {


        private readonly IUserRepository obj;
        private readonly IMapper map;

        public UserController(IUserRepository quota,IMapper map)
        {
            this.obj = quota;
            this.map = map;
        }


    }
}
