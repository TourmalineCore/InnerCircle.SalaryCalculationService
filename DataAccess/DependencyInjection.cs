using Microsoft.Extensions.DependencyInjection;

namespace Salarycalculation.DataAccess
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddSingleton<FakeDataBase>();

            return services;
        }
    }
}
