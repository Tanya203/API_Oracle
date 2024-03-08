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

        [HttpGet]
        public async Task<IActionResult> AutoSchedule()
        {
            var month = "06/2024";
            await _procedureServices.AutoSchedule(month);
            return Ok("Success");
        }
    }
}
