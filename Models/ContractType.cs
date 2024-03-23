using System;
using System.Collections.Generic;

namespace API.Models;

public partial class ContractType
{
    public string CtId { get; set; } = null!;

    public string? ContractTypeName { get; set; }

    public string? TkmId { get; set; }

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();

    public virtual TimeKeepingMethod? Tkm { get; set; }
}
