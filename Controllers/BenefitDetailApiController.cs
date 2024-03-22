using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("/GetStaffBenefitDetail")]
        public async Task<IActionResult> GetStaffBenefitDetail()
        {
            var result = await _benefitDeatailServices.GetStaffBenefitDetail();
            return Ok(result);
        }

        [HttpGet("/SearchStaffBenefitDetail")]
        public async Task<IActionResult> SearchStaffBenefitDetail(string search)
        {
            var result = await _benefitDeatailServices.SearchStaffBenefitDetail(search);
            return Ok(result);
        }

        [HttpPost("/AddBenefitDetail")]
        public async Task<IActionResult> CreateBenefitDetail(BenefitDetail benefitDetail)
        {
            var result = await _benefitDeatailServices.CreateBenefitDetail(benefitDetail);
            return Ok(result);
        }
        [HttpPut("/UpdateBenefitDetail")]
        public async Task<IActionResult> UpdateBenefitDetail(BenefitDetail benefitDetail)
        {
            var result = await _benefitDeatailServices.UpdateBenefitDetail(benefitDetail);
            return Ok(result);
        }
        [HttpDelete("/DeleteBenefitDetail")]
        public async Task<IActionResult> DeleteBenefitDetail(string bnID, string staffID)
        {
            var result = await _benefitDeatailServices.DeleteBenefitDetail(bnID, staffID);
            return Ok(result);
        }
    }
}
