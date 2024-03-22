using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using test_api.Services;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PositionApiController : Controller
    {
        private readonly PositionServices _positionServices;

        public PositionApiController(PositionServices positionServices)
        {
            _positionServices = positionServices;
        }

        [HttpGet("/GetAllPosition")]
        public async Task<IActionResult> GetAllPosition()
        {
            var result = await _positionServices.GetAllPosition();
            return Ok(result);
        }

        [HttpGet("/SearchPosition")]
        public async Task<IActionResult> SearchPosition(string search)
        {
            var result = await _positionServices.SearchPosition(search);
            return Ok(result);
        }

        [HttpPost("/AddPosition")]
        public async Task<IActionResult> CreatePosition(Position position)
        {
            var result = await _positionServices.CreatePosition(position);
            return Ok(result);
        }
        [HttpPut("/UpdatePosition")]
        public async Task<IActionResult> UpdateBenefit(Position position)
        {
            var result = await _positionServices.UpdatePosition(position);
            return Ok(result);
        }
        [HttpDelete("/DeletePosition")]
        public async Task<IActionResult> DeletePosition(string psID)
        {
            var result = await _positionServices.DeletePosition(psID);
            return Ok(result);
        }
    }
}
