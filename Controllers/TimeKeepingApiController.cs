using API.Services;
using Microsoft.AspNetCore.Mvc;
using test_api.Services;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    
    public class TimeKeepingApiController : Controller
    {
        private readonly TimeKeepingServices _timeKeepingServices;
        public TimeKeepingApiController(TimeKeepingServices timeKeepingServices)
        {
            _timeKeepingServices = timeKeepingServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTimeKeeping()
        {
            var result = await _timeKeepingServices.GetAllTimeKeeping();
            return Ok(result);
        }
    }
}
