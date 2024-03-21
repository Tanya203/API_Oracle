using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class WorkScheduleDetailServices
    {
        private readonly ModelContext _modelContext;

        public WorkScheduleDetailServices(ModelContext modelContext)
        {
            _modelContext = modelContext;
        }

        public async Task<List<object>> GetAllWorkScheduleDetail()
        {
            var workScheduleDetail = await _modelContext.WorkScheduleDetails.ToListAsync();

            return workScheduleDetail.Select(s => new
            {
                s.WsId,
                s.StaffId,
                s.DateOff,
                s.Note,
            }).Cast<object>().ToList();
        }
        public async Task<List<object>> GetDayOffUsed()
        {
            var workScheduleDetail = await _modelContext.DayOffUseds.ToListAsync();

            return workScheduleDetail.Select(s => new
            {
                s.WsId,
                s.WorkDate,
                s.StaffId,
                s.FullName,
                s.PositionName,
                s.DepartmentName
            }).Cast<object>().ToList();
        }
        public async Task<List<object>> GetAllStafWorlScheduleDetail()
        {
            var workScheduleDetail = await _modelContext.StaffWorkScheduleDetails.ToListAsync();

            return workScheduleDetail.Select(s => new
            {
                s.WsId,
                s.WorkDate,
                s.StaffId,
                s.FullName,
                s.PositionName,
                s.DepartmentName,
                s.DateOff,
                s.DayOff
            }).Cast<object>().ToList();
        }
        public async Task<IActionResult> CreateWorkScheduleDetail(WorkScheduleDetail workScheduleDetail)
        {
            try
            {
                _modelContext.WorkScheduleDetails.Add(workScheduleDetail);
                await _modelContext.SaveChangesAsync();
                return new StatusCodeResult(StatusCodes.Status200OK);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
        public async Task<IActionResult> UpdateWorkScheduleDetail(WorkScheduleDetail workScheduleDetail)
        {
            try
            {
                _modelContext.WorkScheduleDetails.Update(workScheduleDetail);
                await _modelContext.SaveChangesAsync();
                return new StatusCodeResult(StatusCodes.Status200OK);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
