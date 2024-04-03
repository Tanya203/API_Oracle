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
        [HttpGet("/GetStaffWorlScheduleDetailById")]
        public async Task<IActionResult> GetStaffWorlScheduleDetailById(string wsId)
        {
            var result = await _workScheduleDetailServices.GetStaffWorlScheduleDetailById(wsId);
            return Ok(result);
        }

        [HttpGet("/SearchStaffWorlScheduleDetailById")]
        public async Task<IActionResult> SearchStaffWorlScheduleDetailById(string wsId,string search)
        {
            var result = await _workScheduleDetailServices.SearchStaffWorlScheduleDetailById(wsId, search);
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
