using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Department
{
    public string DpId { get; set; } = null!;

    public string? DepartmentName { get; set; }

    public virtual ICollection<Position> Positions { get; set; } = new List<Position>();
}
