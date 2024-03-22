using API.Models;
using Microsoft.AspNetCore.Mvc;
using API.Services;

namespace API.Controllers
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

        [HttpGet("/SearchShiftType")]
        public async Task<IActionResult> SearchShiftType(string search)
        {
            var result = await _shiftTypeServices.SearchShiftType(search);
            return Ok(result);
        }

        [HttpPost("/AddShiftType")]
        public async Task<IActionResult> CreateShiftType(ShiftType shiftType)
        {
            var result = await _shiftTypeServices.CreateShiftType(shiftType);
            return Ok(result);
        }
        [HttpPut("/UpdateShiftType")]
        public async Task<IActionResult> UpdateShiftType(ShiftType shiftType)
        {
            var result = await _shiftTypeServices.UpdateShiftType(shiftType);
            return Ok(result);
        }
        [HttpDelete("/DeleteShiftType")]
        public async Task<IActionResult> DeleteShiftType(string stID)
        {
            var result = await _shiftTypeServices.DeleteShiftType(stID);
            return Ok(result);
        }
    }
}
