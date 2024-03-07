using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class WorkScheduleServices
    {
        private readonly ModelContext _modelContext;

        public WorkScheduleServices(ModelContext modelContext)
        {
            _modelContext = modelContext;
        }

        public async Task<List<object>> GetAllWorkSchedule()
        {
            var workSchedule = await _modelContext.WorkSchedules.ToListAsync();

            return workSchedule.Select(s => new
            {
                s.WsId,
                s.WorkDate,
            }).Cast<object>().ToList();
        }
    }
}
