using API.Models;
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

        [HttpGet("/GetAllTimeKeeping")]
        public async Task<IActionResult> GetAllTimeKeeping()
        {
            var result = await _timeKeepingServices.GetAllTimeKeeping();
            return Ok(result);
        }
        [HttpGet("/GetStaffTimeKeeping")]
        public async Task<IActionResult> GetStaffTimeKeeping()
        {
            var result = await _timeKeepingServices.GetStaffTimeKeeping();
            return Ok(result);
        }

        [HttpPost("/AddTimeKeeping")]
        public async Task<IActionResult> CreateTimeKeepingf(TimeKeeping timeKeeping)
        {
            var result = await _timeKeepingServices.CreateTimeKeeping(timeKeeping);
            return Ok(result);
        }

        [HttpDelete("/DeleteTimeKeeping")]
        public async Task<IActionResult> DeleteTimeKeeing(string wsID, string staffID, string shiftID)
        {
            var result = await _timeKeepingServices.DeleteTimeKeeping(wsID, staffID, shiftID);
            return Ok(result);
        }
    }
}

