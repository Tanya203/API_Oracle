using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class TimeKeepingMethodServices
    {
        private readonly ModelContext _modelContext;

        public TimeKeepingMethodServices(ModelContext modelContext)
        {
            _modelContext = modelContext;
        }
        public async Task<List<object>> GetAllTimeKeepingMethod()
        {
            var timeKeepingMethods = await _modelContext.TimeKeepingMethods.ToListAsync();

            return timeKeepingMethods.Select(s => new
            {
                s.TkmId,
                s.TimeKeepingMethodName,
            }).Cast<object>().ToList();
        }
        public async Task<List<object>> SearchTimeKeepingMethod(string search)
        {
            search = search.ToLower();
            var timeKeepingMethods = await _modelContext.TimeKeepingMethods.ToListAsync();

            return timeKeepingMethods.Select(s => new
            {
                s.TkmId,
                s.TimeKeepingMethodName,
            }).Where(s => s.TkmId.ToLower().Contains(search) ||
                     s.TimeKeepingMethodName != null && s.TimeKeepingMethodName.ToLower().Contains(search)).Cast<object>().ToList();
        }
        public async Task<IActionResult> CreateTimeKeepingMethod(TimeKeepingMethod timeKeepingMethod)
        {
            try
            {
                _modelContext.TimeKeepingMethods.Add(timeKeepingMethod);
                await _modelContext.SaveChangesAsync();
                return new StatusCodeResult(StatusCodes.Status200OK);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
        public async Task<IActionResult> UpdateTimeKeepingMethod(TimeKeepingMethod timeKeepingMethod)
        {
            try
            {
                _modelContext.TimeKeepingMethods.Update(timeKeepingMethod);
                await _modelContext.SaveChangesAsync();
                return new StatusCodeResult(StatusCodes.Status200OK);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
        public async Task<IActionResult> DeleteTimeKeepingMethod(string tkmID)
        {
            try
            {
                TimeKeepingMethod delete = _modelContext.TimeKeepingMethods.FirstOrDefault(s => s.TkmId == tkmID);
                _modelContext.TimeKeepingMethods.Remove(delete);
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
