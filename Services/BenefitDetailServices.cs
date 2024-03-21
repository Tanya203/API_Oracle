using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class BenefitDetailServices
    {
        private readonly ModelContext _modelContext;

        public BenefitDetailServices(ModelContext modelContext)
        {
            _modelContext = modelContext;
        }

        public async Task<List<object>> GetAllBenefitDetail()
        {
            var benefitDetail = await _modelContext.BenefitDetails.ToListAsync();

            return benefitDetail.Select(s => new
            {
                s.BnId,
                s.StaffId,
                s.Note
            }).Cast<object>().ToList();
        }
        public async Task<IActionResult> CreateBenefitDetail([FromBody] BenefitDetail benefitDetail)
        {
            try
            {
                _modelContext.BenefitDetails.Add(benefitDetail);
                await _modelContext.SaveChangesAsync();
                return new StatusCodeResult(StatusCodes.Status200OK);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
        public async Task<IActionResult> UpdateBenefitDetail(BenefitDetail benefitDetail)
        {
            try
            {
                _modelContext.BenefitDetails.Update(benefitDetail);
                await _modelContext.SaveChangesAsync();
                return new StatusCodeResult(StatusCodes.Status200OK);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
        public async Task<IActionResult> DeleteBenefitDetail(string bnID, string staffID)
        {
            try
            {
                BenefitDetail delete = _modelContext.BenefitDetails.FirstOrDefault(s => s.BnId == bnID && s.StaffId == staffID);
                _modelContext.BenefitDetails.Remove(delete);
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
