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
    }
}
