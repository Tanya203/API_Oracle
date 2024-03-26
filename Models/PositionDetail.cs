using System;
using System.Collections.Generic;

namespace API.Models;

public partial class PositionDetail
{
    public string PsId { get; set; } = null!;

    public string? DepartmentName { get; set; }

    public string? PositionName { get; set; }

    public decimal? Count { get; set; }
}
