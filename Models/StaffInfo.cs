using System;
using System.Collections.Generic;

namespace API.Models;

public partial class StaffInfo
{
    public string StaffId { get; set; } = null!;

    public string? PositionName { get; set; }

    public string? DepartmentName { get; set; }

    public string? ContractTypeName { get; set; }

    public string? Account { get; set; }

    public string? Id { get; set; }

    public string? FullName { get; set; }

    public DateTime? DateOfBrith { get; set; }

    public string? Address { get; set; }

    public string? Gender { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? EducationLevel { get; set; }

    public DateTime? EntryDate { get; set; }

    public DateTime? ContractDuration { get; set; }

    public string? Status { get; set; }

    public decimal? DayOff { get; set; }

    public decimal? BasicSalary { get; set; }

    public decimal? Benefit { get; set; }

    public byte[]? Picture { get; set; }

    public DateTime? LockDate { get; set; }
}
