using System;
using System.Collections.Generic;

namespace API.Models;

public partial class StaffBenefitDetail
{
    public string BnId { get; set; } = null!;

    public string? BenefitName { get; set; }

    public decimal? Amount { get; set; }

    public string? Note { get; set; }

    public string StaffId { get; set; } = null!;

    public string? PositionName { get; set; }

    public string? DepartmentName { get; set; }

    public string? FullName { get; set; }
}
