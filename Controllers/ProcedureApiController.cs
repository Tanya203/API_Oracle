using API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

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

        [HttpPost("/AutoSchedule")]
        public async Task<IActionResult> AutoSchedule(string month)
        {
            var result = await _procedureServices.AutoSchedule(month);
            return Ok(result);
        }

        [HttpPost("/AutoScheduleDate")]
        public async Task<IActionResult> AutoScheduleDate(DateTime date)
        {
            var result = await _procedureServices.AutoScheduleDate(date);
            return Ok(result);
        }

        [HttpPut("/AutoUpdateMonthSalaryDetail")]
        public async Task<IActionResult> AutoUpdateMonthSalaryDetail(string month)
        {
            var result = await _procedureServices.AutoUpdateMonthSalaryDetail(month);
            return Ok(result);
        }

        [HttpPut("/AddValue")]
        public async Task<IActionResult> AddValue()
        {
            var result = await _procedureServices.AddValue();
            return Ok(result);
        }
        
        [HttpPut("/TimeKeeping")]
        public async Task<IActionResult> TimeKeeping(string staffID)
        {
            var result = await _procedureServices.TimeKeeping(staffID);
            return Ok(result);
        }

        [HttpDelete("/DeleteWorkSchedule")]
        public async Task<IActionResult> DeleteWorkSchedule(string wsID)
        {
            var result = await _procedureServices.DeleteWorkSchedule(wsID);
            return Ok(result);
        }

        [HttpDelete("/DeleteWorkScheduleDetail")]
        public async Task<IActionResult> DeleteWorkScheduleDetail(string wsID, string staffID)
        {
            var result =  await _procedureServices.DeleteWorkScheduleDetail(wsID, staffID);
            return Ok(result);
        }

        [HttpDelete("/DeleteTimeKeeping")]
        public async Task<IActionResult> DeleteTimeKeeping(string wsID, string staffID, string shiftID)
        {
            var result = await _procedureServices.DeleteTimeKeeping(wsID, staffID, shiftID);
            return Ok(result);
        }
    }
}
