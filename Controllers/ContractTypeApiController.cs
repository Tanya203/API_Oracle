using API.Services;
using Microsoft.AspNetCore.Mvc;
using test_api.Services;

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

        [HttpGet]
        public async Task<IActionResult> GetAllContractTypes()
        {
            var result = await _contractTypeServices.GetAllContractType();
            return Ok(result);
        }
    }
}
