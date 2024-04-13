namespace API.Models;

public partial class MonthSalary
{
    public string MsId { get; set; } = null!;

    public string? Month { get; set; }

    public virtual ICollection<MonthSalaryDetail>? MonthSalaryDetails { get; set; } = new List<MonthSalaryDetail>();
}
