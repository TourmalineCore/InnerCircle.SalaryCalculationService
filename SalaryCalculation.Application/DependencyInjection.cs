
using Microsoft.Extensions.DependencyInjection;
using Salarycalculation.DataAccess.HelpServices;
using SalaryCalculation.Application.Services;
using SalaryCalculation.Application.Services.Commands;
using SalaryCalculation.Application.Services.Queries;

namespace SalaryCalculation.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<ITaxDataService, FakeTaxService>();
            services.AddTransient<GetEmployeeMetricsQueryHandler>();
            services.AddTransient<SaveCalculatedSalaryMetrics>();
            services.AddTransient<MetricsCalculationService>();
            return services;
        }
    }
}
