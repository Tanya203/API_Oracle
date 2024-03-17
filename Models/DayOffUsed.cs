using System;
using System.Collections.Generic;

namespace API.Models;

public partial class DayOffUsed
{
    public string WsId { get; set; } = null!;

    public DateTime? WorkDate { get; set; }

    public string StaffId { get; set; } = null!;

    public string? FullName { get; set; }

    public string? PositionName { get; set; }

    public string? DepartmentName { get; set; }
}
