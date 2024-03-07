using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class TimeKeepingMethodServices
    {
        private readonly ModelContext _modelContext;

        public TimeKeepingMethodServices(ModelContext modelContext)
        {
            _modelContext = modelContext;
        }

        public async Task<List<object>> GetAllTimeKeepingMethod()
        {
            var timeKeepingMethods = await _modelContext.TimeKeepingMethods.ToListAsync();

            return timeKeepingMethods.Select(s => new
            {
                s.TkmId,
                s.TimeKeepingMothodName,
            }).Cast<object>().ToList();
        }
    }
}
