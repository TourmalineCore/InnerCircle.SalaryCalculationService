
using SalaryCalculation.Domain;

namespace Salarycalculation.DataAccess.Repositories
{
    public class EmployeeSalaryMetricsRepository
    {
        private readonly FakeDataBase _fakeDataBase;

        public EmployeeSalaryMetricsRepository(FakeDataBase fakeDataBase)
        {
            _fakeDataBase = fakeDataBase;
        }
        public void SaveEmployeeSalaryMetrics(EmployeeFinancialMetrics calculateMetrics)
        {
            _fakeDataBase.SaveAsync(calculateMetrics);
        }
    }
}
