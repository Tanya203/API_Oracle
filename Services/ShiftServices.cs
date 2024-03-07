using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class ShiftServices
    {
        private readonly ModelContext _modelContext;

        public ShiftServices(ModelContext modelContext)
        {
            _modelContext = modelContext;
        }

        public async Task<List<object>> GetAllShift()
        {
            var shift = await _modelContext.Shifts.ToListAsync();

            return shift.Select(s => new
            {
                s.ShiftId,
                s.ShiftName,
                s.BeginTime,
                s.EndTime,
            }).Cast<object>().ToList();
        }
    }
}
