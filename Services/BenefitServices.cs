using Microsoft.EntityFrameworkCore;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Services
{
    public class BenefitServices
    {
        private readonly ModelContext _modelContext;

        public BenefitServices(ModelContext modelContext)
        {
            _modelContext = modelContext;
        }

        public async Task<List<object>> GetAllBenefit()
        {
            var benefit = await _modelContext.Benefits.ToListAsync();

            return benefit.Select(s => new
            {
                s.BnId,
                s.BenefitName,
                s.Amount
            }).Cast<object>().ToList();
        }
        public async Task<List<object>> CountBenefit()
        {
            var benefit = await _modelContext.CountBenefits.ToListAsync();

            return benefit.Select(s => new
            {
                s.BnId,
                s.BenefitName,
                s.Amount,
                s.StaffQuantity,
                s.Totalamount,
            }).Cast<object>().ToList();
        }
        public async Task<List<object>> SearchCountBenefit(string search)
        {
            search = search.ToLower();

            var benefit = await _modelContext.CountBenefits.ToListAsync();

            return benefit.Select(s => new
            {
                s.BnId,
                s.BenefitName,
                s.Amount,
                s.StaffQuantity,
                s.Totalamount,
            }).Where(s => s.BnId.Contains(search) ||
                    s.BenefitName.ToLower().Contains(search) ||
                    s.Amount.ToString().Contains(search) ||
                    s.StaffQuantity.ToString().Contains(search) ||
                    s.Totalamount.ToString().Contains(search)).Cast<object>().ToList();
        }
        public async Task<IActionResult> CreateBenefit(Benefit benefit)
        {
            try
            {
                _modelContext.Benefits.Add(benefit);
                await _modelContext.SaveChangesAsync();
                return new StatusCodeResult(StatusCodes.Status200OK);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
        public async Task<IActionResult> UpdateBenefit(Benefit benefit)
        {
            try
            {
                _modelContext.Benefits.Update(benefit);
                await _modelContext.SaveChangesAsync();
                return new StatusCodeResult(StatusCodes.Status200OK);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
        public async Task<IActionResult> DeleteBenefit(string bnID)
        {
            try
            {
                Benefit delete = _modelContext.Benefits.FirstOrDefault(s => s.BnId == bnID);
                _modelContext.Benefits.Remove(delete);
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
