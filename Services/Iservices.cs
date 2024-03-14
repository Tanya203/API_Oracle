using API.Models;
using API.Services;
using System.Reflection.Metadata.Ecma335;

namespace test_api.Services
{
    public static class Iservices
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ShiftTypeServices>();
            services.AddScoped<BenefitServices>();
            services.AddScoped<ContractTypeServices>();
            services.AddScoped<BenefitDetailServices>();
            services.AddScoped<DepartmentServices>();
            services.AddScoped<PositionServices>();
            services.AddScoped<ShiftServices>();
            services.AddScoped<StaffServices>();
            services.AddScoped<TimeKeepingMethodServices>();
            services.AddScoped<WorkScheduleServices>();
            services.AddScoped<WorkScheduleDetailServices>();
            services.AddScoped<ProcedureServices>();
            services.AddScoped<TimeKeepingServices>();
            return services;
        }
    }
}
