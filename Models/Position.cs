namespace API.Models;

public partial class Position
{
    public string PsId { get; set; } = null!;

    public string? DpId { get; set; }

    public string? PositionName { get; set; }

    public virtual Department? Dp { get; set; }

    public virtual ICollection<Staff>? Staff { get; set; } = new List<Staff>();
}
