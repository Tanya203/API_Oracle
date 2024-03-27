using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("/GetShiftDetail")]
        public async Task<IActionResult> GetShiftDetail()
        {
            var result = await _shiftServices.GetShiftDetail();
            return Ok(result);
        }

        [HttpGet("/SearchShiftDetail")]
        public async Task<IActionResult> SearchShiftDetail(string search)
        {
            var result = await _shiftServices.SearchShiftDetail(search);
            return Ok(result);
        }

        [HttpPost("/AddShift")]
        public async Task<IActionResult> CreateShift(Shift shift)
        {
            var result = await _shiftServices.CreateShìt(shift);
            return Ok(result);
        }
        [HttpPut("/UpdateShift")]
        public async Task<IActionResult> UpdateShift(Shift shift)
        {
            var result = await _shiftServices.UpdateShift(shift);
            return Ok(result);
        }
        [HttpDelete("/DeleteShift")]
        public async Task<IActionResult> DeleteShift(string shiftID)
        {
            var result = await _shiftServices.DeleteShift(shiftID);
            return Ok(result);
        }
    }
}
