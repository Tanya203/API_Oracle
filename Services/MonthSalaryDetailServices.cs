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
        public async Task<string> CreateMonthSalaryDetailServices(string msID, string staffID)
        {
            try
            {
                MonthSalaryDetail add = new MonthSalaryDetail()
                {
                    MsId = msID,
                    StaffId = staffID,
                };
                _modelContext.MonthSalaryDetails.Add(add);
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
