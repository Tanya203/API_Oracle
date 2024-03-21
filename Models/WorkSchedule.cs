using System;
using System.Collections.Generic;

namespace API.Models;

public partial class WorkSchedule
{
    public string WsId { get; set; } = null!;

    public DateTime? WorkDate { get; set; }

    public virtual ICollection<WorkScheduleDetail>? WorkScheduleDetails { get; set; } = new List<WorkScheduleDetail>();
}
