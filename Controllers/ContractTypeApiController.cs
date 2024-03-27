using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ContractTypeApiController : Controller
    {
        private readonly ContractTypeServices _contractTypeServices;

        public ContractTypeApiController(ContractTypeServices contractTypeServices)
        {
            _contractTypeServices = contractTypeServices;
        }

        [HttpGet("/GetAllContractType")]
        public async Task<IActionResult> GetAllContractTypes()
        {
            var result = await _contractTypeServices.GetAllContractType();
            return Ok(result);
        }

        [HttpGet("/GetContractTypeDetail")]
        public async Task<IActionResult> GetContractTypeDetail()
        {
            var result = await _contractTypeServices.GetContractTypeDetail();
            return Ok(result);
        }

        [HttpGet("/SearchContractTypeDetail")]
        public async Task<IActionResult> SearchContractTypes(string search)
        {
            var result = await _contractTypeServices.SearchContractTypeDetail(search);
            return Ok(result);
        }

        [HttpPost("/AddContractType")]
        public async Task<IActionResult> CreateBenefit(ContractType contractType)
        {
            var result = await _contractTypeServices.CreateContractType(contractType);
            return Ok(result);
        }
        [HttpPut("/UpdateContractType")]
        public async Task<IActionResult> UpdateBenefit(ContractType contractType)
        {
            var result = await _contractTypeServices.UpdateContractType(contractType);
            return Ok(result);
        }
        [HttpDelete("/DeleteContractType")]
        public async Task<IActionResult> DeleteContractType(string ctID)
        {
            var result = await _contractTypeServices.DeleteContractType(ctID);
            return Ok(result);
        }
    }
}
