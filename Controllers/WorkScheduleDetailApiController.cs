using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class WorkScheduleDetailApiController : Controller
    {
        private readonly WorkScheduleDetailServices _workScheduleDetailServices;

        public WorkScheduleDetailApiController(WorkScheduleDetailServices workScheduleDetailServices)
        {
            _workScheduleDetailServices = workScheduleDetailServices;
        }

        [HttpGet("/GetAllWorkScheduleDetail")]
        public async Task<IActionResult> GetAllWorkScheduleDetail()
        {
            var result = await _workScheduleDetailServices.GetAllWorkScheduleDetail();
            return Ok(result);
        }
        [HttpGet("/GetDayOffUsed")]
        public async Task<IActionResult> GetDayOffUsed()
        {
            var result = await _workScheduleDetailServices.GetDayOffUsed();
            return Ok(result);
        }
        [HttpGet("/GetStaffWorkScheduleDetailById")]
        public async Task<IActionResult> GetStaffWorkScheduleDetailById(string wsId)
        {
            var result = await _workScheduleDetailServices.GetStaffWorkScheduleDetailById(wsId);
            return Ok(result);
        }

        [HttpGet("/SearchStaffWorkScheduleDetailById")]
        public async Task<IActionResult> SearchStaffWorkScheduleDetailById(string wsId,string search)
        {
            var result = await _workScheduleDetailServices.SearchStaffWorkScheduleDetailById(wsId, search);
            return Ok(result);
        }

        [HttpPost("/AddWorkScheduleDetail")]
        public async Task<IActionResult> CreateWorkScheduleDetail(WorkScheduleDetail workScheduleDetail)
        {
            var result = await _workScheduleDetailServices.CreateWorkScheduleDetail(workScheduleDetail);
            return Ok(result);
        }

        [HttpPut("/UpdateWorkScheduleDetail")]
        public async Task<IActionResult> UpdateWorkScheduleDetail(WorkScheduleDetail workScheduleDetail)
        {
            var result = await _workScheduleDetailServices.UpdateWorkScheduleDetail(workScheduleDetail);
            return Ok(result);
        }
    }
}
