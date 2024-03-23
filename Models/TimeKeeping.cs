using System;
using System.Collections.Generic;

namespace API.Models;

public partial class TimeKeeping
{
    public string WsId { get; set; } = null!;

    public string StaffId { get; set; } = null!;

    public string ShiftId { get; set; } = null!;

    public TimeSpan? CheckIn { get; set; }

    public TimeSpan? CheckOut { get; set; }

    public virtual Shift? Shift { get; set; } = null!;

    public virtual WorkScheduleDetail? WorkScheduleDetail { get; set; } = null!;
}
