using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Shift
{
    public string ShiftId { get; set; } = null!;

    public string? ShiftName { get; set; }

    public TimeSpan? BeginTime { get; set; }

    public TimeSpan? EndTime { get; set; }

    public virtual ICollection<TimeKeeping> TimeKeepings { get; set; } = new List<TimeKeeping>();
}
