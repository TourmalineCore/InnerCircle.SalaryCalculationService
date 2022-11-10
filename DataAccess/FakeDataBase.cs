using SalaryCalculation.Domain;

namespace Salarycalculation.DataAccess
{
    public class FakeDataBase
    {
        private readonly Dictionary<long, EmployeeFinancialMetrics> _data = new Dictionary<long, EmployeeFinancialMetrics>();

        public void SaveAsync(EmployeeFinancialMetrics employeeFinancialMetrics)
        {
            _data.Add(employeeFinancialMetrics.EmployeeId, employeeFinancialMetrics);
        }

        public EmployeeFinancialMetrics? Get(long empId)
        {
            _data.TryGetValue(empId, out var employeeFinancialMetrics);

            return employeeFinancialMetrics;
        }
    }
}
