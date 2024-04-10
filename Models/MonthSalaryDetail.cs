using System;
using System.Collections.Generic;

namespace API.Models;

public partial class MonthSalaryDetail
{
    public string MsId { get; set; } = null!;

    public string StaffId { get; set; } = null!;

    public decimal? BasicSalary { get; set; }

    public decimal? TotalWorkHours { get; set; }

    public decimal? TotalBenefit { get; set; }

    public virtual MonthSalary? Ms { get; set; } = null!;

    public virtual Staff? Staff { get; set; } = null!;
}
