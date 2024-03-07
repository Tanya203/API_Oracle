using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class PositionServices
    {
        private readonly ModelContext _modelContext;

        public PositionServices(ModelContext modelContext)
        {
            _modelContext = modelContext;
        }

        public async Task<List<object>> GetAllPosition()
        {
            var position = await _modelContext.Positions.ToListAsync();

            return position.Select(s => new
            {
                s.PsId,
                s.DpId,
                s.PositionName
            }).Cast<object>().ToList();
        }
    }
}
