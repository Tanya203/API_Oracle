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
                s.ShiftName,
                s.BeginTime,
                s.EndTime,
            }).Cast<object>().ToList();
        }
        public async Task<IActionResult> CreateShìt(Shift shift)
        {
            try
            {
                _modelContext.Shifts.Add(shift);
                await _modelContext.SaveChangesAsync();
                return new StatusCodeResult(StatusCodes.Status200OK);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
        public async Task<IActionResult> UpdateShift(Shift shift)
        {
            try
            {
                _modelContext.Shifts.Update(shift);
                await _modelContext.SaveChangesAsync();
                return new StatusCodeResult(StatusCodes.Status200OK);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
        public async Task<IActionResult> DeleteShift(string shiftID)
        {
            try
            {
                Shift delete = _modelContext.Shifts.FirstOrDefault(s => s.ShiftId == shiftID);
                _modelContext.Shifts.Remove(delete);
                await _modelContext.SaveChangesAsync();
                return new StatusCodeResult(StatusCodes.Status200OK);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
