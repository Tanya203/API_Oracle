using API.Models;
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
        public async Task<List<object>> GetStaffTimeKeeping()
        {
            var timeKeeping = await _modelContext.StaffTimeKeepings.ToListAsync();

            return timeKeeping.Select(s => new
            {
                s.WsId,
                s.WorkDate,
                s.StaffId,
                s.ShiftName,
                s.CheckIn,
                s.CheckOut,
            }).Cast<object>().ToList();
        }
    }
}
