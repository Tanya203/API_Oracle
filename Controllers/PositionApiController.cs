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

        [HttpGet]
        public async Task<IActionResult> GetAllPosition()
        {
            var result = await _positionServices.GetAllPosition();
            return Ok(result);
        }
    }
}
