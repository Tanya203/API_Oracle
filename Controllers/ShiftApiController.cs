using API.Services;
using Microsoft.AspNetCore.Mvc;
using test_api.Services;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ShiftApiController : Controller
    {
        private readonly ShiftServices _shiftServices;

        public ShiftApiController(ShiftServices shiftServices)
        {
            _shiftServices = shiftServices;
        }

        [HttpGet("/GetAllShift")]
        public async Task<IActionResult> GetAllShift()
        {
            var result = await _shiftServices.GetAllShift();
            return Ok(result);
        }
    }
}
