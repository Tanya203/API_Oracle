using System;
using System.Collections.Generic;

namespace API.Models;

public partial class ShiftDetail
{
    public string ShiftId { get; set; } = null!;

    public string? ShiftTypeName { get; set; }

    public string? ShiftName { get; set; }

    public TimeSpan? BeginTime { get; set; }

    public TimeSpan? EndTime { get; set; }
}
