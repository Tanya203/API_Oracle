using API.Models;
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
    }
}
