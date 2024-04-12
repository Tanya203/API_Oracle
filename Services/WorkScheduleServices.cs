using API.Models;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<List<object>> SearchWorkSchedule(string search)
        {
            search = search.ToLower();
            var workSchedule = await _modelContext.WorkSchedules.ToListAsync();

            return workSchedule.Select(s => new
            {
                s.WsId,
                s.WorkDate,
            }).Where(s => s.WsId.ToLower().Contains(search) ||
                    s.WorkDate.ToString().Contains(search)).Cast<object>().ToList();
        }        
        public async Task<string> CreateWorkSchedule(WorkSchedule workSchedule)
        {
            try
            {
                _modelContext.WorkSchedules.Add(workSchedule);
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
