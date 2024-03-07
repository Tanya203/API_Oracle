using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class WorkSchedileDetailApiController : Controller
    {
        private readonly WorkScheduleDetailServices _workScheduleDetailServices;

        public WorkSchedileDetailApiController(WorkScheduleDetailServices workScheduleDetailServices)
        {
            _workScheduleDetailServices = workScheduleDetailServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWorkScheduleDetail()
        {
            var result = await _workScheduleDetailServices.GetAllWorkScheduleDetail();
            return Ok(result);
        }
    }
}
