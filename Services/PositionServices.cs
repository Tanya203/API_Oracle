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
        public async Task<List<object>> GetPositionDetail()
        {
            var position = await _modelContext.PositionDetails.ToListAsync();

            return position.Select(s => new
            {
                s.PsId,
                s.DepartmentName,
                s.PositionName,
                s.CountPs
            }).Cast<object>().ToList();
        }
        public async Task<List<object>> SearchPosition(string search)
        {
            search = search.ToLower();

            var position = await _modelContext.Positions.ToListAsync();

            return position.Select(s => new
            {
                s.PsId,
                s.DpId,
                s.PositionName
            }).Where(s => s.PsId.ToLower().Contains(search) ||
                     s.DpId != null && s.DpId.ToLower().Contains(search) ||
                     s.PositionName != null && s.PositionName.ToLower().Contains(search)).Cast<object>().ToList();
        }

        public async Task<string> CreatePosition(Position position)
        {
            try
            {
                _modelContext.Positions.Add(position);
                await _modelContext.SaveChangesAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
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
