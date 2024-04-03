using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet("/GetStaffTimeKeepingById")]
        public async Task<IActionResult> GetStaffTimeKeepingById(string wsId)
        {
            var result = await _timeKeepingServices.GetStaffTimeKeepingById(wsId);
            return Ok(result);
        }

        [HttpGet("/SearchStaffTimeKeepinById")]
        public async Task<IActionResult> SearchStaffTimeKeepinById(string wsId,string search)
        {
            var result = await _timeKeepingServices.SearchStaffTimeKeepinById(wsId, search);
            return Ok(result);
        }

        [HttpPost("/AddTimeKeeping")]
        public async Task<IActionResult> CreateTimeKeepingf(TimeKeeping timeKeeping)
        {
            var result = await _timeKeepingServices.CreateTimeKeeping(timeKeeping);
            return Ok(result);
        }
    }
}

