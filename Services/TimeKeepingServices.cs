using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class TimeKeepingServices
    {
        private readonly ModelContext _modelContext;

        public TimeKeepingServices(ModelContext modelContext)
        {
            _modelContext = modelContext;
        }

        public async Task<List<object>> GetAllTimeKeeping()
        {
            var timeKeeping = await _modelContext.TimeKeepings.ToListAsync();

            return timeKeeping.Select(s => new
            {
                s.WsId,
                s.StaffId,
                s.ShiftId,
                s.CheckIn,
                s.CheckOut,
            }).Cast<object>().ToList();
        }
        public async Task<List<object>> GetStaffTimeKeepingById(string wsID)
        {
            var timeKeeping = await _modelContext.StaffTimeKeepings.ToListAsync();

            return timeKeeping.Select(s => new
            {
                s.WsId,
                s.WorkDate,
                s.StaffId,
                s.ShiftId,
                s.FullName,
                s.PositionName,
                s.DepartmentName,
                s.ShiftName,
                s.CheckIn,
                s.CheckOut,
            }).Where(s => s.WsId == wsID).Cast<object>().ToList();
        }
        public async Task<List<object>> GetStaffTimeKeepingByDate(DateTime date)
        {
            var timeKeeping = await _modelContext.StaffTimeKeepings.ToListAsync();

            return timeKeeping.Select(s => new
            {
                s.WsId,
                s.WorkDate,
                s.StaffId,
                s.ShiftId,
                s.FullName,
                s.PositionName,
                s.DepartmentName,
                s.ShiftName,
                s.CheckIn,
                s.CheckOut,
            }).Where(s => s.WorkDate.Date == date.Date).Cast<object>().ToList();
        }
        public async Task<List<object>> SearchStaffTimeKeepinById(string wsID,string search)
        {
            search = search.ToLower();
            var timeKeeping = await _modelContext.StaffTimeKeepings.ToListAsync();

            return timeKeeping.Select(s => new
            {
                s.WsId,
                s.WorkDate,
                s.StaffId,
                s.ShiftId,
                s.FullName,
                s.PositionName,
                s.DepartmentName,
                s.ShiftName,
                s.CheckIn,
                s.CheckOut,
            }).Where(s => s.WsId == wsID && 
                     (s.StaffId.ToLower().Contains(search) ||
                     s.FullName.ToLower().Contains(search) ||
                     s.PositionName.ToLower().Contains(search) ||
                     s.DepartmentName.ToLower().Contains(search) ||
                     s.ShiftName.ToLower().Contains(search) ||
                     s.CheckIn.ToString().Contains(search) ||
                     s.CheckOut.ToString().Contains(search))).Cast<object>().ToList();
        }
        public async Task<string> CreateTimeKeeping(TimeKeeping timeKeeping)
        {
            try
            {
                _modelContext.TimeKeepings.Add(timeKeeping);
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
