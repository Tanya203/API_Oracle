using Microsoft.EntityFrameworkCore;
using API.Models;

namespace test_api.Services
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
    }
}
