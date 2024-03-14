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
                s.StId,
                s.CheckIn,
                s.CheckOut,
            }).Cast<object>().ToList();
        }
    }
}
