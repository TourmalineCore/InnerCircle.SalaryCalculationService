namespace SalaryCalculation.Application.Services.Dtos
{
    public class EmployeeDto
    {
        public long Id { get; set; }
        public double Pay { get; set; }
        public double HourlyCostFact { get; set; }
        public double HourlyCostHand { get; set; }
        public double Earnings { get; set; }
        public double Expenses { get; set; }
        public double Profit { get; set; }
        public double ProfitAbility { get; set; }
        public double GrossSalary { get; set; }
        public double Retainer { get; set; }
        public double NetSalary { get; set; }

        public EmployeeDto() { }

        public EmployeeDto(long id, double pay, double hourlyCostFact,
            double hourlyCostHand, double earnings, double expenses,
            double profit, double profitability, double grossSalary, double netSaalry, 
            double retainer
            )
        {
            Id = id;
            Pay = pay;
            HourlyCostFact = hourlyCostFact;
            HourlyCostHand = hourlyCostHand;
            Earnings = earnings;
            Expenses = expenses;
            Profit = profit;
            ProfitAbility = profitability;
            GrossSalary = grossSalary;
            NetSalary = netSaalry;
            Retainer = retainer;
        }
    }
}
