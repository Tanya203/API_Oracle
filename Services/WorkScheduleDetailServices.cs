using API.Models;
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
            }).Cast<object>().ToList();
        }
    }
}
