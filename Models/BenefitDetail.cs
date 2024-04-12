namespace API.Models;

public partial class BenefitDetail
{
    public string BnId { get; set; } = null!;

    public string StaffId { get; set; } = null!;

    public string? Note { get; set; }

    public virtual Benefit? Bn { get; set; } = null!;

    public virtual Staff? Staff { get; set; } = null!;
}
