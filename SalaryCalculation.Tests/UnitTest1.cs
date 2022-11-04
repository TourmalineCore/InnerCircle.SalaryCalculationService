using SalaryCalculation.Domain;

namespace SalaryCalculation.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var employeeFinancialMetrics = new EmployeeFinancialMetrics();
            var value = employeeFinancialMetrics.CalculateHourCostFact();

            Assert.Equal(0, value);
        }
    }
}