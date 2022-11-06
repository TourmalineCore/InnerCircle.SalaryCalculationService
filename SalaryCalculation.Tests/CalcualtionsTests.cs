using SalaryCalculation.Domain;

namespace SalaryCalculation.Tests
{
    public class CalcualtionsTests
    {
        [Fact]
        public void TestMetrics1()
        {
            var employeeId = 1;
            var ratePerHour = 400.00;
            var fullSalary = 20000.00;
            var employmentType = 1.0;
            
            EmployeeFinancialMetrics metrics = new EmployeeFinancialMetrics(employeeId, 
                ratePerHour, 
                fullSalary, 
                employmentType, true);

            metrics.CalculateMetrics(0.15, 15279, 0.13);

            Assert.Equal(20000, metrics.Salary);
            Assert.Equal(230.45, metrics.HourCostFact);
            Assert.Equal(125.0, metrics.HourCostHand);
            Assert.Equal(54133.33, metrics.Income);
            Assert.Equal(31187.85, metrics.Expenses);
            Assert.Equal(22945.48, metrics.Profit);
            Assert.Equal(42.39, metrics.ProfitAbility);
            Assert.Equal(23000, metrics.SalaryBeforeTax);
            Assert.Equal(20010, metrics.SalaryAftertax);
        }
        [Fact]
        public void TestMetrics2()
        {
            var employeeId = 1;
            var ratePerHour = 400.00;
            var fullSalary = 20000.00;
            double employmentType = 0.5;

            EmployeeFinancialMetrics metrics = new EmployeeFinancialMetrics(employeeId,
                ratePerHour,
                fullSalary,
                employmentType, false);

            metrics.CalculateMetrics(0.15, 15279, 0.13);

            Assert.Equal(10000, metrics.Salary);
            Assert.Equal(119.26, metrics.HourCostFact);
            Assert.Equal(62.50, metrics.HourCostHand);
            Assert.Equal(27066.67, metrics.Income);
            Assert.Equal(16139.85, metrics.Expenses);
            Assert.Equal(10926.82, metrics.Profit);
            Assert.Equal(40.37, metrics.ProfitAbility);
            Assert.Equal(11500, metrics.SalaryBeforeTax);
            Assert.Equal(10005, metrics.SalaryAftertax);
        }
    }
}