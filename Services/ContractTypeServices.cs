using API.Models;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> CreateContractType(ContractType contractType)
        {
            try
            {
                _modelContext.ContractTypes.Add(contractType);
                await _modelContext.SaveChangesAsync();
                return new StatusCodeResult(StatusCodes.Status200OK);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
        public async Task<IActionResult> UpdateContractType(ContractType contractType)
        {
            try
            {
                _modelContext.ContractTypes.Update(contractType);
                await _modelContext.SaveChangesAsync();
                return new StatusCodeResult(StatusCodes.Status200OK);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
        public async Task<IActionResult> DeleteContractType(string ctID)
        {
            try
            {
                ContractType delete = _modelContext.ContractTypes.FirstOrDefault(s => s.CtId == ctID);
                _modelContext.ContractTypes.Remove(delete);
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
