using Microsoft.Extensions.DependencyInjection;
using Salarycalculation.DataAccess.HelpServices;
using Salarycalculation.DataAccess.Repositories;

namespace Salarycalculation.DataAccess
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddTransient<ITaxDataService, FakeTaxService>();
            services.AddSingleton<FakeDataBase>();
            services.AddTransient<EmployeeSalaryMetricsRepository>();
            return services;
        }
    }
}
