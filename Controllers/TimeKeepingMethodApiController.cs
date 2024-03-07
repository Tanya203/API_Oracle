using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TimeKeepingMethodApiController : Controller
    {
        private readonly TimeKeepingMethodServices _timeKeepingMethodServices;

        public TimeKeepingMethodApiController(TimeKeepingMethodServices timeKeepingMethodServices)
        {
            _timeKeepingMethodServices = timeKeepingMethodServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTimeKeepingMethod()
        {
            var result = await _timeKeepingMethodServices.GetAllTimeKeepingMethod();
            return Ok(result);
        }
    }
}
