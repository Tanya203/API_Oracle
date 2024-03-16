using API.Services;
using Microsoft.AspNetCore.Mvc;
using test_api.Services;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BenefitDetailApiController : Controller
    {
        private readonly BenefitDetailServices _benefitDeatailServices;

        public BenefitDetailApiController(BenefitDetailServices benefitDeatailServices)
        {
            _benefitDeatailServices = benefitDeatailServices;
        }

        [HttpGet("/GetAllBenefitDetail")]
        public async Task<IActionResult> GetAllBenefitService()
        {
            var result = await _benefitDeatailServices.GetAllBenefitDetail();
            return Ok(result);
        }
    }
}
