namespace API.Models;

public partial class StaffTimeKeeping
{
    public string WsId { get; set; } = null!;

    public DateTime? WorkDate { get; set; }

    public string StaffId { get; set; } = null!;

    public string? FullName { get; set; }

    public string? PositionName { get; set; }

    public string? DepartmentName { get; set; }

    public string? ShiftName { get; set; }

    public TimeSpan? CheckIn { get; set; }

    public TimeSpan? CheckOut { get; set; }
}
