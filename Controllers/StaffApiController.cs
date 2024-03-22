using API.Models;
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

        [HttpGet("/SearchStaffInfo")]
        public async Task<IActionResult> SearchStaffInfo(string search)
        {
            var result = await _staffServices.SearchStaffInfo(search);
            return Ok(result);
        }

        [HttpPost("/AddStaff")]
        public async Task<IActionResult> CreateStaff(Staff staff)
        {
            var result = await _staffServices.CreateStaff(staff);
            return Ok(result);
        }

        [HttpPut("/UpdateStaff")]
        public async Task<IActionResult> UpdateStaff(Staff staff)
        {
            var result = await _staffServices.UpdateStaff(staff);
            return Ok(result);
        }

        [HttpDelete("/DeleteStaff")]
        public async Task<IActionResult> DeleteStaff(string staffID)
        {
            var result = await _staffServices.DeleteStaff(staffID);
            return Ok(result);
        }
    }
}
