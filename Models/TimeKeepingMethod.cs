using System;
using System.Collections.Generic;

namespace API.Models;

public partial class TimeKeepingMethod
{
    public string TkmId { get; set; } = null!;

    public string? TimeKeepingMothodName { get; set; }

    public virtual ICollection<ContractType> ContractTypes { get; set; } = new List<ContractType>();
}
