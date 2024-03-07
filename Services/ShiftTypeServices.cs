using Microsoft.EntityFrameworkCore;
using API.Models;

namespace test_api.Services
{
    public class ShiftTypeServices
    {
        private readonly ModelContext _modelContext;

        public ShiftTypeServices(ModelContext modelContext)
        {
            _modelContext = modelContext;
        }

        public async Task<List<object>> GetAllShiftType()
        {
            var shiftType = await _modelContext.ShiftTypes.ToListAsync();

            return shiftType.Select(s => new
            {
                s.StId,
                s.ShiftTypeName,
            }).Cast<object>().ToList();
        }
    }
}
