using API.Models;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<List<object>> SearchDepartment(string search)
        {
            search = search.ToLower();

            var department = await _modelContext.Departments.ToListAsync();

            return department.Select(s => new
            {
                s.DpId,
                s.DepartmentName,
            }).Where(s => s.DpId.ToLower().Contains(search) ||
                     s.DepartmentName != null && s.DepartmentName.ToLower().Contains(search)).Cast<object>().ToList();
        }

        public async Task<string> CreateDepartment(Department department)
        {
            try
            {
                _modelContext.Departments.Add(department);
                await _modelContext.SaveChangesAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
        public async Task<string> UpdateDepartment(Department department)
        {
            try
            {
                _modelContext.Departments.Update(department);
                await _modelContext.SaveChangesAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
        public async Task<string> DeleteDepartment(string dpID)
        {
            try
            {
                Department delete = _modelContext.Departments.FirstOrDefault(s => s.DpId == dpID);
                _modelContext.Departments.Remove(delete);
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
