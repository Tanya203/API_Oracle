using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Salary
{
    public string StaffId { get; set; } = null!;

    public string? FullName { get; set; }

    public string? DepartmentName { get; set; }

    public string? PositionName { get; set; }

    public decimal? BasicSalary { get; set; }

    public decimal? TotalWorkHours { get; set; }

    public decimal? TotalBenefit { get; set; }

    public decimal? TotalSalary { get; set; }

    public string? Month { get; set; }
}
