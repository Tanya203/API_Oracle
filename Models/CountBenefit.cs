using System;
using System.Collections.Generic;

namespace API.Models;

public partial class CountBenefit
{
    public string BnId { get; set; } = null!;

    public string? BenefitName { get; set; }

    public decimal? Amount { get; set; }

    public decimal? StaffQuantity { get; set; }

    public decimal? Totalamount { get; set; }
}
