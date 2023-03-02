using AutoMapper;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using RailwayReservationSystem.Repositories;


namespace RailwayReservationSystem.Controllers
{
    //This Controller will be used for SignUp and Login .
    //Token is genrated once the user signup credentials are verified
    //and will be checked once the user is logged in to the system 


    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IUserRepository user;
        private readonly ITokenHandler token;
        private readonly IMapper map;


        #region SignUp and Login 
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
           //validation part




            //logic 
           
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
            //Session for Email and FirstName
            //HttpContext.Session.SetString("Email", request.Email);
            //HttpContext.Session.SetString("FirstName", request.FirstName);
            



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







            //Email Notification to user after successfully signup

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("jasper.frami@ethereal.email"));
            email.To.Add(MailboxAddress.Parse(userdto.Email));
            email.Subject = "Welcome to Railway Reservation System !";
            email.Body = new TextPart(TextFormat.Html)
            {
                Text = "Hi " + userdto.FirstName + "\n" + "" +
                "Below are the credentials you used to signed up in the system :" + "\n" + "" +
                   "UserId : " + userdto.UserId + "\n" + "" + "Password : " + userdto.Password + "\n" + "\n" + "Have a Safe Journey !"
            };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, MailKit.Security.SecureSocketOptions.StartTls); //try with gmail as well
            smtp.Authenticate("jasper.frami@ethereal.email", "Bve3XeCyncFyYU61GM");
            smtp.Send(email);
            smtp.Disconnect(true);


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

        #endregion






    }
}
