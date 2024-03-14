using System;
using System.Collections.Generic;

namespace API.Models;

public partial class WorkScheduleDetail
{
    public string WsId { get; set; } = null!;

    public string StaffId { get; set; } = null!;

    public bool? DateOff { get; set; }

    public string? Note { get; set; }

    public virtual Staff Staff { get; set; } = null!;

    public virtual ICollection<TimeKeeping> TimeKeepings { get; set; } = new List<TimeKeeping>();

    public virtual WorkSchedule Ws { get; set; } = null!;
}
