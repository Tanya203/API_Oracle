using System;
using System.Collections.Generic;

namespace API.Models;

public partial class ContractTypeDetail
{
    public string CtId { get; set; } = null!;

    public string? ContractTypeName { get; set; }

    public string? TimeKeepingMethodName { get; set; }

    public decimal? Count { get; set; }
}
