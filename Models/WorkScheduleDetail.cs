using System;
using System.Collections.Generic;

namespace API.Models;

public partial class WorkScheduleDetail
{
    public string WsId { get; set; } = null!;

    public string StaffId { get; set; } = null!;

    public string ShiftId { get; set; } = null!;

    public string StId { get; set; } = null!;

    public bool? DateOff { get; set; }

    public DateTime? CheckIn { get; set; }

    public DateTime? CheckOut { get; set; }

    public virtual Shift Shift { get; set; } = null!;

    public virtual ShiftType St { get; set; } = null!;

    public virtual Staff Staff { get; set; } = null!;

    public virtual WorkSchedule Ws { get; set; } = null!;
}
