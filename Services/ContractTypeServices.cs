﻿using API.Models;
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
        public async Task<List<object>> GetContractTypeDetail()
        {
            var shiftType = await _modelContext.ContractTypeDetails.ToListAsync();

            return shiftType.Select(s => new
            {
                s.CtId,
                s.ContractTypeName,
                s.TimeKeepingMethodName,
                s.Count
            }).Cast<object>().ToList();
        }
        public async Task<List<object>> SearchContractTypeDetail(string search)
        {
            search = search.ToLower();

            var shiftType = await _modelContext.ContractTypeDetails.ToListAsync();

            return shiftType.Select(s => new
            {
                s.CtId,
                s.ContractTypeName,
                s.TimeKeepingMethodName,
                s.Count
            }).Where(s => s.CtId.ToLower().Contains(search) ||
                     s.TimeKeepingMethodName != null && s.TimeKeepingMethodName.ToLower().Contains(search) || 
                     s.ContractTypeName != null && s.ContractTypeName.ToLower().Contains(search) ||
                     s.Count != null && s.Count.ToString().Contains(search)).Cast<object>().ToList();
        }
        public async Task<string> CreateContractType(ContractType contractType)
        {
            try
            {
                _modelContext.ContractTypes.Add(contractType);
                await _modelContext.SaveChangesAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
        public async Task<string> UpdateContractType(ContractType contractType)
        {
            try
            {
                _modelContext.ContractTypes.Update(contractType);
                await _modelContext.SaveChangesAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
        public async Task<string> DeleteContractType(string ctID)
        {
            try
            {
                ContractType delete = _modelContext.ContractTypes.FirstOrDefault(s => s.CtId == ctID);
                _modelContext.ContractTypes.Remove(delete);
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
