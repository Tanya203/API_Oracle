using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class PositionServices
    {
        private readonly ModelContext _modelContext;

        public PositionServices(ModelContext modelContext)
        {
            _modelContext = modelContext;
        }

        public async Task<List<object>> GetAllPosition()
        {
            var position = await _modelContext.Positions.ToListAsync();

            return position.Select(s => new
            {
                s.PsId,
                s.DpId,
                s.PositionName
            }).Cast<object>().ToList();
        }
        public async Task<IActionResult> CreatePosition(Position position)
        {
            try
            {
                _modelContext.Positions.Add(position);
                await _modelContext.SaveChangesAsync();
                return new StatusCodeResult(StatusCodes.Status200OK);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
        public async Task<IActionResult> UpdatePosition(Position position)
        {
            try
            {
                _modelContext.Positions.Update(position);
                await _modelContext.SaveChangesAsync();
                return new StatusCodeResult(StatusCodes.Status200OK);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
        public async Task<IActionResult> DeletePosition(string psID)
        {
            try
            {
                Position delete = _modelContext.Positions.FirstOrDefault(s => s.PsId == psID);
                _modelContext.Positions.Remove(delete);
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
