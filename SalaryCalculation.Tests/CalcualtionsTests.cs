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
            var parking = true;
            
            EmployeeFinancialMetrics metrics = new EmployeeFinancialMetrics(employeeId, 
                ratePerHour, 
                fullSalary, 
                employmentType, parking);

            metrics.CalculateMetrics(0.15, 15279, 0.13);

            Assert.Equal(20000, Math.Round(metrics.Salary,2));
            Assert.Equal(230.45, Math.Round(metrics.HourlyCostFact,2));
            Assert.Equal(125.0, Math.Round(metrics.HourlyCostHand,2));
            Assert.Equal(54133.33, Math.Round(metrics.Earnings,2));
            Assert.Equal(31187.85, Math.Round(metrics.Expenses,2));
            Assert.Equal(22945.48, Math.Round(metrics.Profit,2));
            Assert.Equal(42.39, Math.Round(metrics.ProfitAbility,2));
            Assert.Equal(23000, Math.Round(metrics.GrossSalary,2));
            Assert.Equal(20010, Math.Round(metrics.NetSalary,2));
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

            Assert.Equal(10000, Math.Round(metrics.Salary,2));
            Assert.Equal(119.26, Math.Round(metrics.HourlyCostFact,2));
            Assert.Equal(62.50, Math.Round(metrics.HourlyCostHand,2));
            Assert.Equal(27066.67, Math.Round(metrics.Earnings,2));
            Assert.Equal(16139.85, Math.Round(metrics.Expenses,2));
            Assert.Equal(10926.82, Math.Round(metrics.Profit,2));
            Assert.Equal(40.37, Math.Round(metrics.ProfitAbility,2));
            Assert.Equal(11500, Math.Round(metrics.GrossSalary,2));
            Assert.Equal(10005, Math.Round(metrics.NetSalary,2));
        }

        [Fact]
        public void TestMetrics3()
        {
            var employeeId = 1;
            var ratePerHour = 400.00;
            var fullSalary = 1.00;
            double employmentType = 1.0;

            EmployeeFinancialMetrics metrics = new EmployeeFinancialMetrics(employeeId,
                ratePerHour,
                fullSalary,
                employmentType, true);

            metrics.CalculateMetrics(0.15, 15279, 0.13);

            Assert.Equal(1, Math.Round(metrics.Salary,2));
            Assert.Equal(34.68, Math.Round(metrics.HourlyCostFact,2));
            Assert.Equal(0.01, Math.Round(metrics.HourlyCostHand, 2));
            Assert.Equal(54133.33, Math.Round(metrics.Earnings, 2));
            Assert.Equal(4693.17, Math.Round(metrics.Expenses,2));
            Assert.Equal(49440.16, Math.Round(metrics.Profit,2));
            Assert.Equal(91.33, Math.Round(metrics.ProfitAbility,2));
            Assert.Equal(1.15, Math.Round(metrics.GrossSalary,2));
            Assert.Equal(1, Math.Round(metrics.NetSalary,2));
        }

        [Fact]
        public void TestMetrics4()
        {
            var employeeId = 1;
            var ratePerHour = 400.00;
            var fullSalary = 0;
            double employmentType = 1.0;

            EmployeeFinancialMetrics metrics = new EmployeeFinancialMetrics(employeeId,
                ratePerHour,
                fullSalary,
                employmentType, true);

            metrics.CalculateMetrics(0.15, 15279, 0.13);

            Assert.Equal(0, Math.Round(metrics.Salary, 2));
            Assert.Equal(34.67, Math.Round(metrics.HourlyCostFact, 2));
            Assert.Equal(0, Math.Round(metrics.HourlyCostHand, 2));
            Assert.Equal(54133.33, Math.Round(metrics.Earnings, 2));
            Assert.Equal(4691.85, Math.Round(metrics.Expenses, 2));
            Assert.Equal(49441.48, Math.Round(metrics.Profit, 2));
            Assert.Equal(91.33, Math.Round(metrics.ProfitAbility, 2));
            Assert.Equal(0, Math.Round(metrics.GrossSalary, 2));
            Assert.Equal(0, Math.Round(metrics.NetSalary, 2));
        }

        [Fact]
        public void TestMetricsWithNullBasicMetrics()
        {
            var employeeId = 1;
            var ratePerHour = 0;
            var fullSalary = 0;
            double employmentType = 0;

            EmployeeFinancialMetrics metrics = new EmployeeFinancialMetrics(employeeId,
                ratePerHour,
                fullSalary,
                employmentType, true);

            Assert.Throws<ArgumentException>(() => metrics.CalculateMetrics(0.15, 15279, 0.13));
        }

        [Fact]
        public void TestMetrics5()
        {
            var employeeId = 1;
            var ratePerHour = 1;
            var fullSalary = 1;
            double employmentType = 1;

            EmployeeFinancialMetrics metrics = new EmployeeFinancialMetrics(employeeId,
                ratePerHour,
                fullSalary,
                employmentType, true);

            Assert.Throws<ArgumentException>(() => metrics.CalculateMetrics(0.15, 15279, 0.13));
        }
    }
}