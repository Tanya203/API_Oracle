using API.Services;
using Microsoft.AspNetCore.Mvc;
using test_api.Services;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProcedureApiController : Controller
    {
        private readonly ProcedureServices _procedureServices;
        public ProcedureApiController(ProcedureServices procedureServices)
        {
            _procedureServices = procedureServices;
        }

        [HttpGet("/AutoSchedule")]
        public async Task<IActionResult> AutoSchedule(string month)
        {
            await _procedureServices.AutoSchedule(month);
            return Ok("Success");
        }
        [HttpGet("/Salary")]
        public async Task<IActionResult> MonthlySalaryStatistics(string month)
        {
            var result = await _procedureServices.MonthlySalaryStatistics(month);
            return Ok(result);
        }
        [HttpPut("/TimeKeeping")]
        public async Task<IActionResult> TimeKeeping(string staffID)
        {
            await _procedureServices.TimeKeeping(staffID);
            return Ok("Success");
        }

        [HttpDelete("/DeleteWorkSchedule")]
        public async Task<IActionResult> DeleteWorkSchedule(string wsID)
        {
            await _procedureServices.DeleteWorkSchedule(wsID);
            return Ok("Success");
        }

        [HttpDelete("/DeleteWorkScheduleDetail")]
        public async Task<IActionResult> DeleteWorkScheduleDetail(string wsID, string staffID)
        {
            await _procedureServices.DeleteWorkScheduleDetail(wsID, staffID);
            return Ok("Success");
        }

        [HttpDelete("/DeleteTimeKeeping")]
        public async Task<IActionResult> DeleteTimeKeeping(string wsID, string staffID, string shiftID)
        {
            await _procedureServices.DeleteTimeKeeping(wsID, staffID, shiftID);
            return Ok("Success");
        }
    }
}
