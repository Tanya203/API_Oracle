using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class MonthSalaryDetailServices
    {
        private readonly ModelContext _modelContext;
        public MonthSalaryDetailServices(ModelContext modelContext)
        {
            _modelContext = modelContext;
        }
        public async Task<List<object>> GetAllMonthSalary()
        {
            var workSchedule = await _modelContext.MonthSalaryDetails.ToListAsync();


            return workSchedule.Select(s => new
            {
                s.MsId,
                s.StaffId,
                s.BasicSalary,
                s.TotalWorkHours,
                s.TotalBenefit
            }).Cast<object>().ToList();
        }
        public async Task<List<object>> GetMonthSalary(string month)
        {
            var workSchedule = await _modelContext.Salaries.ToListAsync();

            workSchedule = workSchedule.Where(s => s.Month == month).ToList();

            return workSchedule.Select(s => new
            {
                s.MsId,
                s.StaffId,
                s.FullName,
                s.DepartmentName,
                s.PositionName,
                s.BasicSalary,
                s.TotalWorkHours,
                s.TotalBenefit,
                s.TotalSalary,
                s.Month
            }).Cast<object>().ToList();
        }
        public async Task<string> CreateMonthSalaryDetailServices(MonthSalaryDetail monthSalaryDetail)
        {
            try
            {
                _modelContext.MonthSalaryDetails.Add(monthSalaryDetail);
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
