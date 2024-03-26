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
                s.DateOff,
                s.StaffId,
                s.FullName,
                s.PositionName,
                s.DepartmentName,
                s.Note
            }).Cast<object>().ToList();
        }
        public async Task<List<object>> GetAllStaffWorlScheduleDetail()
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
        public async Task<List<object>> SearchStaffWorlScheduleDetail(string search)
        {
            search = search.ToLower();
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
            }).Where(s => s.WsId.ToLower().Contains(search) ||
                     s.WorkDate.ToString().Contains(search) ||
                     s.StaffId.ToLower().Contains(search) ||
                     s.FullName.ToLower().Contains(search) ||
                     s.PositionName.ToLower().Contains(search) ||
                     s.DepartmentName.ToLower().Contains(search) ||
                     s.DayOff.ToString().Contains(search) ||
                     s.DateOff.ToString().Contains(search)).Cast<object>().ToList();

        }
        public async Task<string> CreateWorkScheduleDetail(WorkScheduleDetail workScheduleDetail)
        {
            try
            {
                _modelContext.WorkScheduleDetails.Add(workScheduleDetail);
                await _modelContext.SaveChangesAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
        public async Task<string> UpdateWorkScheduleDetail(WorkScheduleDetail workScheduleDetail)
        {
            try
            {
                _modelContext.WorkScheduleDetails.Update(workScheduleDetail);
                await _modelContext.SaveChangesAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
    }
}
