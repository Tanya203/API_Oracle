﻿using Microsoft.EntityFrameworkCore;
using API.Models;
using Microsoft.AspNetCore.Mvc;

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
