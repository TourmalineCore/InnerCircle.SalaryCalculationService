
using Microsoft.Extensions.DependencyInjection;
using SalaryCalculation.Application.HelpServices;

namespace SalaryCalculation.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            services.AddTransient<ITaxDataService, FakeTaxService>();

            return services;
        }
    }
}
