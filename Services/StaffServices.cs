using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

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
        public async Task<List<object>> GetAllStaffInfo()
        {
            var staff = await _modelContext.StaffInfos.ToListAsync();

            return staff.Select(s => new
            {
                s.StaffId,
                s.PositionName,
                s.DepartmentName,
                s.ContractTypeName,
                s.Account,
                s.FullName,
                s.DateOfBrith,
                s.Address,
                s.Gender,
                s.Phone,
                s.Email,
                s.EducationLevel,
                s.EntryDate,
                s.ContractDuration,
                s.Status,
                s.DayOff,
                s.BasicSalary,
                s.Benefit,
            }).Cast<object>().ToList();
        }
        public async Task<List<object>> SearchStaffInfo(string search)
        {
            search = search.ToLower();
            var staff = await _modelContext.StaffInfos.ToListAsync();

            return staff.Select(s => new
            {
                s.StaffId,
                s.PositionName,
                s.DepartmentName,
                s.ContractTypeName,
                s.Account,
                s.FullName,
                s.DateOfBrith,
                s.Address,
                s.Gender,
                s.Phone,
                s.Email,
                s.EducationLevel,
                s.EntryDate,
                s.ContractDuration,
                s.Status,
                s.DayOff,
                s.BasicSalary,
                s.Benefit,
            }).Where(s => s.StaffId.ToLower().Contains(search) ||
                     s.PositionName.ToLower().Contains(search) ||
                     s.DepartmentName.ToLower().Contains(search) ||
                     s.ContractTypeName.ToLower().Contains(search) ||
                     s.Account.ToLower().Contains(search) ||
                     s.FullName.ToLower().Contains(search) ||
                     s.DateOfBrith.ToString().Contains(search) ||
                     s.Address.ToLower().Contains(search) ||
                     s.Gender.ToLower().Contains(search) || 
                     s.Phone.Contains(search) ||
                     s.Email.ToLower().Contains(search) ||
                     s.EducationLevel.ToLower().Contains(search) ||
                     s.EntryDate.ToString().Contains(search) ||
                     s.ContractDuration.ToString().Contains(search) ||
                     s.Status.Contains(search) ||
                     s.DayOff.ToString().Contains(search) ||
                     s.BasicSalary.ToString().Contains(search) ||
                     s.Benefit.ToString().Contains(search)).Cast<object>().ToList();
        }
        public async Task<string> CreateStaff(Staff staff)
        {
            try
            {
                _modelContext.Staff.Add(staff);
                await _modelContext.SaveChangesAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
        public async Task<string> UpdateStaff(Staff staff)
        {
            try
            {
                _modelContext.Staff.Update(staff);
                await _modelContext.SaveChangesAsync();
                return "Success"; ;
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
        public async Task<string> DeleteStaff(string staffID)
        {
            try
            {
                Staff delete = _modelContext.Staff.FirstOrDefault(s => s.StaffId == staffID);
                _modelContext.Staff.Remove(delete);
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
