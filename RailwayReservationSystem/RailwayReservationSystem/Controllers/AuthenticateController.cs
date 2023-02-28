using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RailwayReservationSystem.Repositories;
using System.Data;
using System.Text;

namespace RailwayReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IUserRepository user;
        private readonly ITokenHandler token;
        private readonly IMapper map;
       

        public AuthenticateController(IUserRepository user,ITokenHandler token,IMapper map)
        {
            this.user = user;
            this.token = token;
            this.map = map;
        }


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginAsync(Models.DTO.LoginRequest request)
        {
           
           
            var data = await user.Authenticate(request.Email , request.Password,request.Role);
            if(data != null)
            {
                var GenratedToken =await token.GenrateToken(data);
                return Ok(GenratedToken);
            }
            return BadRequest("Username and password is incorrect ");
            
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(Models.DTO.UserSignUpRequest request)
        {

            

            var data = new Models.Domain.User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password=request.Password,
                Gender=request.Gender,




            };
           

            //domain to database
            data = await user.SignUp(data);

            //domain to dto
            var userdto = new Models.DTO.User
            {
                UserId=data.UserId,
                FirstName=data.FirstName,
                LastName=data.LastName,
                Email=data.Email,
                Password=data.Password,
                Gender=data.Gender,
                Role=data.Role,

            };



            //pass data back 
            return Ok(userdto);


        }



        [HttpGet]
        
        public async Task<IActionResult> GetAllUser()
        {
            //fetch data from database-domain
            var data = await user.GetAllUser();

            //convert to dto 
            var Userdto = map.Map<List<Models.DTO.User>>(data);

            //response back 200
            return Ok(Userdto);


        }






    }
}
