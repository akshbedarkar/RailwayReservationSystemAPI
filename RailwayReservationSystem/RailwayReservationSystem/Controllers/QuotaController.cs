
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RailwayReservationSystem.Repositories;

namespace RailwayReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotaController : ControllerBase
    {
        private readonly IQuotaRepository obj;
        
        public QuotaController(IQuotaRepository obj)
        {
            this.obj = obj;
            
        }
        [HttpGet]
        [ActionName("GetAllQuota")]

        public async Task<IActionResult> GetAllQuota()
        {
            var QuotaDetails = await obj.GetAllQuota();
            
            return Ok(QuotaDetails);

        }
    }
}
