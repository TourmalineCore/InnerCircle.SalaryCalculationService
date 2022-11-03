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
            // сохранение в бд
            //double mrot = 15279;
            //double accountingPerYear = 7200;

            //double salary = parameters.FullSalary * parameters.EmploymentType;

            //double salaryBeforeTax = salary + salary * 0.15;
            //double salaryAfterTax = salaryBeforeTax - salaryBeforeTax * 0.13;

            //double ndfl = salaryBeforeTax * 0.13;
            //double ops = mrot * 0.22 + (salaryBeforeTax - mrot) * 0.1;
            //double oms = mrot * 0.051 + (salaryBeforeTax - mrot) * 0.05;
            //double oss = mrot * 0.029;
            //double injury = salaryBeforeTax * 0.002;
            //double accounting = accountingPerYear / 12;

            //double expenses = ndfl + salaryAfterTax + ops + oms + oss + injury + accounting + parameters.ParkingCost;
            //double income = parameters.RatePerHour * hoursInMonth * parameters.EmploymentType;


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
