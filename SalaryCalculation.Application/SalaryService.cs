using SalaryCalculation.Domain;

namespace SalaryCalculation.Application
{
    public class SalaryCalculationParams
    {
        public int Id { get; set; }
        public double RatePerHour { get; set; }
        public double FullSalary { get; set; }
        public double EmploymentType { get; set; }
        public double ParkingCost { get; set; }

    }
    public class SalaryService
    {
        public EmployeeDto Calculate(SalaryCalculationParams parameters)
        {
            double workingDaysInYear = 247;
            double vacation = workingDaysInYear - 24;
            double medical = vacation - 20;
            double workingDaysInMonth = medical / 12;
            double hoursInMonth = workingDaysInMonth * 8;

            var employeeFinancialMetrics = new EmployeeFinancialMetrics(parameters.Id, 
                parameters.RatePerHour, 
                parameters.FullSalary, 
                parameters.EmploymentType, 
                parameters.ParkingCost);

            employeeFinancialMetrics.CalculateMetrics(0.15, hoursInMonth, 15279, 7200, 0.13);
            // save to db

            return new EmployeeDto(
                parameters.Id,
                Math.Round(employeeFinancialMetrics.Salary, 2),
                Math.Round(employeeFinancialMetrics.HourCostFact, 2),
                Math.Round(employeeFinancialMetrics.HourCostHand, 2),
                Math.Round(employeeFinancialMetrics.Income, 2),
                Math.Round(employeeFinancialMetrics.Expenses, 2),
                Math.Round(employeeFinancialMetrics.Profit, 2),
                Math.Round(employeeFinancialMetrics.ProfitAbility, 2),
                Math.Round(employeeFinancialMetrics.SalaryBeforeTax, 2),
                Math.Round(employeeFinancialMetrics.SalaryAftertax, 2)
                );
        }
    }
}
