﻿using API.Models;
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
        public async Task<List<object>> GetDepartmentDetail()
        {
            var department = await _modelContext.DepartmentDetails.ToListAsync();

            return department.Select(s => new
            {
                s.DpId,
                s.DepartmentName,
                s.Count,
            }).Cast<object>().ToList();
        }

        public async Task<List<object>> SearchDepartmentDetail(string search)
        {
            search = search.ToLower();

            var department = await _modelContext.DepartmentDetails.ToListAsync();

            return department.Select(s => new
            {
                s.DpId,
                s.DepartmentName,
                s.Count,
            }).Where(s => s.DpId.ToLower().Contains(search) ||
                     s.DepartmentName != null && s.DepartmentName.ToLower().Contains(search) ||
                     s.Count != null && s.Count.ToString().Contains(search)).Cast<object>().ToList();
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
