using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class WorkScheduleDetailApiController : Controller
    {
        private readonly WorkScheduleDetailServices _workScheduleDetailServices;

        public WorkScheduleDetailApiController(WorkScheduleDetailServices workScheduleDetailServices)
        {
            _workScheduleDetailServices = workScheduleDetailServices;
        }

        [HttpGet("/GetAllWorkScheduleDetail")]
        public async Task<IActionResult> GetAllWorkScheduleDetail()
        {
            var result = await _workScheduleDetailServices.GetAllWorkScheduleDetail();
            return Ok(result);
        }
        [HttpGet("/GetDayOffUsed")]
        public async Task<IActionResult> GetDayOffUsed()
        {
            var result = await _workScheduleDetailServices.GetDayOffUsed();
            return Ok(result);
        }
        [HttpGet("/GetAllStaffWorkScheduleDetail")]
        public async Task<IActionResult> GetAllStaffWorkScheduleDetail()
        {
            var result = await _workScheduleDetailServices.GetAllStafWorlScheduleDetail();
            return Ok(result);
        }
    }
}
