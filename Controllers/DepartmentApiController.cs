﻿using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DepartmentApiController : Controller
    {
        private readonly DepartmentServices _departmentServices;
               
        public DepartmentApiController(DepartmentServices departmentServices)
        {
            _departmentServices = departmentServices;
        }

        [HttpGet("/GetAllDepartment")]
        public async Task<IActionResult> GetAllDepartment()
        {
            var result = await _departmentServices.GetAllDepartment();
            return Ok(result);
        }

        [HttpGet("/GetDepartmentDetail")]
        public async Task<IActionResult> GetDepartmentDetail()
        {
            var result = await _departmentServices.GetDepartmentDetail();
            return Ok(result);
        }

        [HttpGet("/SearchDepartmentDetail")]
        public async Task<IActionResult> SearchDepartmentDetail(string search)
        {
            var result = await _departmentServices.SearchDepartmentDetail(search);
            return Ok(result);
        }

        [HttpPost("/AddDepartment")]
        public async Task<IActionResult> CreateDepartment(Department department)
        {
            var result = await _departmentServices.CreateDepartment(department);
            return Ok(result);
        }
        [HttpPut("/UpdateDepartment")]
        public async Task<IActionResult> UpdateDepartment(Department department)
        {
            var result = await _departmentServices.UpdateDepartment(department);
            return Ok(result);
        }
        [HttpDelete("/DeleteDepartment")]
        public async Task<IActionResult> DeleteDepartment(string dpID)
        {
            var result = await _departmentServices.DeleteDepartment(dpID);
            return Ok(result);
        }
    }
}
