using Microsoft.Extensions.DependencyInjection;
using Salarycalculation.DataAccess.Repositories;

namespace Salarycalculation.DataAccess
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            
            services.AddSingleton<FakeDataBase>();
            services.AddTransient<EmployeeSalaryMetricsRepository>();
            return services;
        }
    }
}
