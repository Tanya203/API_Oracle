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
        public async Task<List<object>> GetStaffBenefitDetail()
        {
            var staffBenefitDetail = await _modelContext.StaffBenefitDetails.ToListAsync();

            return staffBenefitDetail.Select(s => new
            {
                s.BnId,
                s.BenefitName,
                s.Amount,
                s.Note,
                s.StaffId,
                s.PositionName,
                s.DepartmentName,
                s.FullName
            }).Cast<object>().ToList();
        }
        public async Task<List<object>> SearchStaffBenefitDetail(string search)
        {
            search = search.ToLower();

            var staffBenefitDetail = await _modelContext.StaffBenefitDetails.ToListAsync();

            return staffBenefitDetail.Select(s => new
            {
                s.BnId,
                s.BenefitName,
                s.Amount,
                s.Note,
                s.StaffId,
                s.PositionName,
                s.DepartmentName,
                s.FullName
            }).Where(s => s.BnId.ToLower().Contains(search) ||
                    (s.BenefitName != null && s.BenefitName.ToLower().Contains(search)) ||
                    (s.Amount != null && s.Amount.ToString().Contains(search)) ||
                    (s.Note != null && s.Note.ToLower().Contains(search)) ||
                    (s.StaffId.ToLower().Contains(search)) ||
                    (s.PositionName != null && s.PositionName.ToLower().Contains(search)) ||
                    (s.DepartmentName != null && s.DepartmentName.ToLower().Contains(search)) ||
                    (s.FullName != null && s.FullName.ToLower().Contains(search))).Cast<object>().ToList();
        }
        public async Task<string> CreateBenefitDetail([FromBody] BenefitDetail benefitDetail)
        {
            try
            {
                _modelContext.BenefitDetails.Add(benefitDetail);
                await _modelContext.SaveChangesAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
        public async Task<string> UpdateBenefitDetail(BenefitDetail benefitDetail)
        {
            try
            {
                _modelContext.BenefitDetails.Update(benefitDetail);
                await _modelContext.SaveChangesAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
        public async Task<string> DeleteBenefitDetail(string bnID, string staffID)
        {
            try
            {
                BenefitDetail delete = _modelContext.BenefitDetails.FirstOrDefault(s => s.BnId == bnID && s.StaffId == staffID);
                _modelContext.BenefitDetails.Remove(delete);
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
