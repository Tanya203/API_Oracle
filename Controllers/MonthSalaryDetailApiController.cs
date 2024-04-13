using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class MonthSalaryDetailApiController : Controller
    {
        private readonly MonthSalaryDetailServices _monthSalaryDetailServices;
        public MonthSalaryDetailApiController(MonthSalaryDetailServices monthSalaryDetailServices)
        {
            _monthSalaryDetailServices = monthSalaryDetailServices;
        }

        [HttpGet("/GetAllMonthSalary")]
        public async Task<IActionResult> GetAllMonthSalary()
        {
            var result = await _monthSalaryDetailServices.GetAllMonthSalary();
            return Ok(result);
        }

        [HttpGet("/GetMonthSalary")]
        public async Task<IActionResult> GetMonthSalary(string month)
        {
            var result = await _monthSalaryDetailServices.GetMonthSalary(month);
            return Ok(result);
        }

        [HttpPost("/CreateMonthSalaryDetail")]
        public async Task<IActionResult> CreateMonthSalaryDetail(string msID, string staffID)
        {
            var result = await _monthSalaryDetailServices.CreateMonthSalaryDetailServices(msID, staffID);
            return Ok(result);
        }
    }
}
