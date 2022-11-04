namespace SalaryCalculation.Application.Services.Dtos
{
    public class EmployeeDto
    {
        public long Id { get; set; }
        public double Salary { get; set; }
        public double HourCostFact { get; set; }
        public double HourCostHand { get; set; }
        public double Income { get; set; }
        public double Expenses { get; set; }
        public double Profit { get; set; }
        public double ProfitAbility { get; set; }
        public double SalaryBeforeTax { get; set; }
        public double SalaryAftertax { get; set; }

        public EmployeeDto() { }

        public EmployeeDto(long id, double salary, double hourCostFact,
            double hourCostHand, double income, double expenses,
            double profit, double profitability, double salaryBeforeTax, double salaryAfterTax
            )
        {
            Id = id;
            Salary = salary;
            HourCostFact = hourCostFact;
            HourCostHand = hourCostHand;
            Income = income;
            Expenses = expenses;
            Profit = profit;
            ProfitAbility = profitability;
            SalaryBeforeTax = salaryBeforeTax;
            SalaryAftertax = salaryAfterTax;
        }
    }
}
