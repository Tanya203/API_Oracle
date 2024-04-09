namespace API.ViewModels
{
    public class MonthlySalaryStatisticsViewModels
    {
        public string? StaffId { get; set; }

        public string? FullName { get; set; }

        public string? Department {  get; set; }

        public string? Position { get; set; }

        public decimal? BasicSalary { get; set; }

        public decimal? TotalHour { get; set; }

        public decimal? TotalBenefit{ get; set; }

        public decimal? Salary { get; set; }
    }
}
