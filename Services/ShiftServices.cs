using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class ShiftServices
    {
        private readonly ModelContext _modelContext;

        public ShiftServices(ModelContext modelContext)
        {
            _modelContext = modelContext;
        }
        public async Task<List<object>> GetAllShift()
        {
            var shift = await _modelContext.Shifts.ToListAsync();

            return shift.Select(s => new
            {
                s.ShiftId,
                s.StId,
                s.ShiftName,
                s.BeginTime,
                s.EndTime,
            }).Cast<object>().ToList();
        }
        public async Task<List<object>> SearchShift(string search)
        {
            search = search.ToLower();
            var shift = await _modelContext.Shifts.ToListAsync();

            return shift.Select(s => new
            {
                s.ShiftId,
                s.StId, 
                s.ShiftName,
                s.BeginTime,
                s.EndTime,
            }).Where(s => s.ShiftId.ToLower().Contains(search) ||
                     s.StId != null && s.StId.ToLower().Contains(search) ||
                     s.ShiftName != null && s.ShiftName.ToLower().Contains(search) ||
                     s.BeginTime != null && s.BeginTime.ToString().Contains(search) ||
                     s.EndTime != null && s.EndTime.ToString().Contains(search)).Cast<object>().ToList();
        }
        public async Task<string> CreateShìt(Shift shift)
        {
            try
            {
                _modelContext.Shifts.Add(shift);
                await _modelContext.SaveChangesAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
        public async Task<string> UpdateShift(Shift shift)
        {
            try
            {
                _modelContext.Shifts.Update(shift);
                await _modelContext.SaveChangesAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
        public async Task<string> DeleteShift(string shiftID)
        {
            try
            {
                Shift delete = _modelContext.Shifts.FirstOrDefault(s => s.ShiftId == shiftID);
                _modelContext.Shifts.Remove(delete);
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
