using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class WorkScheduleApiController : Controller
    {
        private readonly WorkScheduleServices _workScheduleServices;

        public WorkScheduleApiController(WorkScheduleServices workScheduleServices)
        {
            _workScheduleServices = workScheduleServices;
        }

        [HttpGet("/GetAllWorkSchedule")]
        public async Task<IActionResult> GetAllWorkSchedule()
        {
            var result = await _workScheduleServices.GetAllWorkSchedule();
            return Ok(result);
        }

        [HttpPost("/AddWorkSchedule")]
        public async Task<IActionResult> CreateWorkSchedule(WorkSchedule workSchedule)
        {
            var result = await _workScheduleServices.CreateWorkSchedule(workSchedule);
            return Ok(result);
        }

    }
}
