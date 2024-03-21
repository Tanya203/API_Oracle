using API.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
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
        [HttpPost("/AddBenefit")]
        public async Task<IActionResult> CreateBenefit(Benefit benefit)
        {
            var result = await _benefitServices.CreateBenefit(benefit);
            return Ok(result);
        }
        [HttpPut("/UpdateBenefit")]
        public async Task<IActionResult> UpdateBenefit(Benefit benefit)
        {
            var result = await _benefitServices.UpdateBenefit(benefit);
            return Ok(result);
        }
        [HttpDelete("/DeleteBenefit")]
        public async Task<IActionResult> DeleteBenefit(string bnID)
        {
            var result = await _benefitServices.DeleteBenefit(bnID);
            return Ok(result);
        }
    }
}

