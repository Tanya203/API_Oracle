using Microsoft.EntityFrameworkCore;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace test_api.Services
{
    public class ShiftTypeServices
    {
        private readonly ModelContext _modelContext;

        public ShiftTypeServices(ModelContext modelContext)
        {
            _modelContext = modelContext;
        }

        public async Task<List<object>> GetAllShiftType()
        {
            var shiftType = await _modelContext.ShiftTypes.ToListAsync();

            return shiftType.Select(s => new
            {
                s.StId,
                s.ShiftTypeName,
                s.SalaryCoefficient
            }).Cast<object>().ToList();
        }
        public async Task<List<object>> SearchShiftType(string search)
        {
            search = search.ToLower();
            var shiftType = await _modelContext.ShiftTypes.ToListAsync();

            return shiftType.Select(s => new
            {
                s.StId,
                s.ShiftTypeName,
                s.SalaryCoefficient
            }).Where(s => s.StId.ToLower().Contains(search) ||
                     s.ShiftTypeName != null && s.ShiftTypeName.ToLower().Contains(search) ||
                     s.SalaryCoefficient != null && s.SalaryCoefficient.ToString().Contains(search)).Cast<object>().ToList();
        }
        public async Task<IActionResult> CreateShiftType(ShiftType shiftType)
        {
            try
            {
                _modelContext.ShiftTypes.Add(shiftType);
                await _modelContext.SaveChangesAsync();
                return new StatusCodeResult(StatusCodes.Status200OK);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
        public async Task<IActionResult> UpdateShiftType(ShiftType shiftType)
        {
            try
            {
                _modelContext.ShiftTypes.Update(shiftType);
                await _modelContext.SaveChangesAsync();
                return new StatusCodeResult(StatusCodes.Status200OK);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
        public async Task<IActionResult> DeleteShiftType(string stID)
        {
            try
            {
                ShiftType delete = _modelContext.ShiftTypes.FirstOrDefault(s => s.StId == stID);
                _modelContext.ShiftTypes.Remove(delete);
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
