using API.Models;
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

        [HttpGet("/GetAllTimeKeepingMethod")]
        public async Task<IActionResult> GetAllTimeKeepingMethod()
        {
            var result = await _timeKeepingMethodServices.GetAllTimeKeepingMethod();
            return Ok(result);
        }

        [HttpGet("/SearchTimeKeepingMethod")]
        public async Task<IActionResult> SearchTimeKeepingMethod(string search)
        {
            var result = await _timeKeepingMethodServices.SearchTimeKeepingMethod(search);
            return Ok(result);
        }

        [HttpPost("/AddTimeKeepingMethod")]
        public async Task<IActionResult> CreateTimeKeepingMethod(TimeKeepingMethod timeKeepingMethod)
        {
            var result = await _timeKeepingMethodServices.CreateTimeKeepingMethod(timeKeepingMethod);
            return Ok(result);
        }

        [HttpPut("/UpdateTimeKeepingMethod")]
        public async Task<IActionResult> UpdateTimeKeepingMethod(TimeKeepingMethod timeKeepingMethod)
        {
            var result = await _timeKeepingMethodServices.UpdateTimeKeepingMethod(timeKeepingMethod);
            return Ok(result);
        }

        [HttpDelete("/DeleteTimeKeepingMethod")]
        public async Task<IActionResult> DeleteTimeKeepingMethod(string tkmID)
        {
            var result = await _timeKeepingMethodServices.DeleteTimeKeepingMethod(tkmID);
            return Ok(result);
        }
    }
}
