using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class StaffServices
    {
        private readonly ModelContext _modelContext;

        public StaffServices(ModelContext modelContext)
        {
            _modelContext = modelContext;
        }

        public async Task<List<object>> GetAllStaff()
        {
            var staff = await _modelContext.Staff.ToListAsync();

            return staff.Select(s => new
            {
                s.StaffId,
                s.PsId,
                s.CtId,
                s.Account,
                s.Password,
                s.Id,
                s.LastName,
                s.MiddleName,
                s.FirstName,
                s.DateOfBrith,
                s.HouseNumber,
                s.Street,
                s.Ward,
                s.District,
                s.ProviceCity,
                s.Gender,
                s.Phone,
                s.Email,
                s.EducationLevel,
                s.EntryDate,
                s.ContractDuration,
                s.Status,
                s.DayOff,
                s.BasicSalary,
                s.Picture,
                s.LockDate
            }).Cast<object>().ToList();
        }
    }
}
