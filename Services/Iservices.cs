using System.Reflection.Metadata.Ecma335;

namespace test_api.Services
{
    public static class Iservices
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ShiftTypeServices>();
            services.AddScoped<BenefitServices>();
            return services;
        }
    }
}
