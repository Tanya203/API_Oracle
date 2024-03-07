using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class DepartmentServices
    {
        private readonly ModelContext _modelContext;

        public DepartmentServices(ModelContext modelContext)
        {
            _modelContext = modelContext;
        }

        public async Task<List<object>> GetAllDepartment()
        {
            var department = await _modelContext.Departments.ToListAsync();

            return department.Select(s => new
            {
                s.DpId,
                s.DepartmentName,
            }).Cast<object>().ToList();
        }
    }
}
