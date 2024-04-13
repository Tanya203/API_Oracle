namespace API.Models;

public partial class Benefit
{
    public string BnId { get; set; } = null!;

    public string? BenefitName { get; set; }

    public decimal? Amount { get; set; }

    public virtual ICollection<BenefitDetail>? BenefitDetails { get; set; } = new List<BenefitDetail>();
}
