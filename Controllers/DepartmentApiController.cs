using API.Services;
using Microsoft.AspNetCore.Mvc;
using test_api.Services;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DepartmentApiController : Controller
    {
        private readonly DepartmentServices _departmentServices;
               
        public DepartmentApiController(DepartmentServices departmentServices)
        {
            _departmentServices = departmentServices;
        }

        [HttpGet("/GetAllDepartment")]
        public async Task<IActionResult> GetAllDepartment()
        {
            var result = await _departmentServices.GetAllDepartment();
            return Ok(result);
        }
        
    }
}
