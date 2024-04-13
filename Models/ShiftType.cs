namespace API.Models;

public partial class ShiftType
{
    public string StId { get; set; } = null!;

    public string? ShiftTypeName { get; set; }

    public decimal? SalaryCoefficient { get; set; }

    public virtual ICollection<Shift>? Shifts { get; set; } = new List<Shift>();
}
