
using Microsoft.Extensions.DependencyInjection;
using SalaryCalculation.Application.Services.Commands;
using SalaryCalculation.Application.Services.Queries;

namespace SalaryCalculation.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            
            services.AddTransient<GetEmployeeMetricsQueryHandler>();
            services.AddTransient<CalculateMetricsCommandHandler>();

            return services;
        }
    }
}
