using System;
using System.Collections.Generic;

namespace API.Models;

public partial class ShiftType
{
    public string StId { get; set; } = null!;

    public string? ShiftTypeName { get; set; }

    public decimal? SalaryCoefficient { get; set; }

    public virtual ICollection<TimeKeeping> TimeKeepings { get; set; } = new List<TimeKeeping>();
}
