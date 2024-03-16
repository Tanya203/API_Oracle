using Microsoft.AspNetCore.Mvc;
using test_api.Services;

namespace test_api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ShiftTypesApiController : Controller
    {
        private readonly ShiftTypeServices _shiftTypeServices;
        
        public ShiftTypesApiController(ShiftTypeServices shiftTypeServices)
        {
            _shiftTypeServices = shiftTypeServices;
        }

        [HttpGet("/GetAllShiftType")]
        public async Task<IActionResult> GetAllShiftType() 
        {
            var result = await _shiftTypeServices.GetAllShiftType();
            return Ok(result);
        }
    }
}
