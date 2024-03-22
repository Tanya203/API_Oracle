namespace API.Models;

public partial class Shift
{
    public string ShiftId { get; set; } = null!;

    public string? ShiftName { get; set; }

    public TimeSpan? BeginTime { get; set; }

    public TimeSpan? EndTime { get; set; }

    public string? StId { get; set; }

    public virtual ShiftType? St { get; set; }

    public virtual ICollection<TimeKeeping> TimeKeepings { get; set; } = new List<TimeKeeping>();
}
