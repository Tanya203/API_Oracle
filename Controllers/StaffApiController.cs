using API.Services;
using Microsoft.AspNetCore.Mvc;
using test_api.Services;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class StaffApiController : Controller
    {
        private readonly StaffServices _staffServices;

        public StaffApiController(StaffServices staffServices)
        {
            _staffServices = staffServices;
        }

        [HttpGet("/GetAllStaff")]
        public async Task<IActionResult> GetAllStaff()
        {
            var result = await _staffServices.GetAllStaff();
            return Ok(result);
        }
        [HttpGet("/GetAllStaffInfo")]
        public async Task<IActionResult> GetAllStaffInfo()
        {
            var result = await _staffServices.GetAllStaffInfo();
            return Ok(result);
        }
    }
}
