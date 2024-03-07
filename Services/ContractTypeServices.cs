using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class ContractTypeServices
    {
        private readonly ModelContext _modelContext;

        public ContractTypeServices(ModelContext modelContext)
        {
            _modelContext = modelContext;
        }

        public async Task<List<object>> GetAllContractType()
        {
            var shiftType = await _modelContext.ContractTypes.ToListAsync();           

            return shiftType.Select(s => new
            {
                s.CtId,
                s.TkmId,
                s.ContractTypeName,
            }).Cast<object>().ToList();
            
        }
    }
}
