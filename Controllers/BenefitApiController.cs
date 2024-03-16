using Microsoft.AspNetCore.Mvc;
using test_api.Services;

namespace test_api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BenefitApiController : Controller
    {
        private readonly BenefitServices _benefitServices;

        public BenefitApiController(BenefitServices benefitServices)
        {
            _benefitServices = benefitServices;
        }

        [HttpGet("/GetAllBenefit")]
        public async Task<IActionResult> GetAllBenefit()
        {
            var result = await _benefitServices.GetAllBenefit();
            return Ok(result);
        }
        [HttpGet("/CountBenefit")]
        public async Task<IActionResult> CountBenefit()
        {
            var result = await _benefitServices.CountBenefit();
            return Ok(result);
        }
    }
}

