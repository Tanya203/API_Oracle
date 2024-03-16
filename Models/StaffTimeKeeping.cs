using System;
using System.Collections.Generic;

namespace API.Models;

public partial class StaffTimeKeeping
{
    public string WsId { get; set; } = null!;

    public DateTime? WorkDate { get; set; }

    public string StaffId { get; set; } = null!;

    public string? ShiftName { get; set; }

    public TimeSpan? CheckIn { get; set; }

    public TimeSpan? CheckOut { get; set; }
}
