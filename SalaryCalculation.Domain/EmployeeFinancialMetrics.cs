namespace SalaryCalculation.Domain
{
    public class EmployeeFinancialMetrics
    {
        public long Id { get; private set; }
        public long EmployeeId { get; private set; }
        public double Salary { get; private set; }
        public double HourCostFact { get; private set; }
        public double HourCostHand { get; private set; }
        public double Income { get; private set; }
        public double Expenses { get; private set; }
        public double Profit { get; private set; }
        public double ProfitAbility { get; private set; }
        public double SalaryBeforeTax { get; private set; }
        public double SalaryAftertax { get; private set; }
        public double RatePerHour { get; private set; }
        public double FullSalary { get; private set; }
        public double EmploymentType { get; private set; }
        public double ParkingCost { get; private set; }

        public EmployeeFinancialMetrics(long employeeId, double ratePerHour, double fullSalary, double employmentType, double parkingCost)
        {
            EmployeeId = employeeId;
            RatePerHour = ratePerHour;
            FullSalary = fullSalary;
            EmploymentType = employmentType;
            ParkingCost = parkingCost;
        }
        private void CalculateSalary()
        {
            Salary = FullSalary * EmploymentType;
        }
        private void CalculateHourCostFact(double hoursInMonth)
        {
            HourCostFact = Math.Round(Expenses / hoursInMonth, 2);
        }
        private void CalculateHourCostHand()
        {
            HourCostHand = Math.Round(Salary / 160, 2);
        }
        private void CalculateIncome(double hoursInMonth)
        {
            Income = RatePerHour * hoursInMonth * EmploymentType;
        }
        private double Ndfl() => SalaryBeforeTax * 0.13;
        private double Ops(double mrot) => mrot * 0.22 + (SalaryBeforeTax - mrot) * 0.1;
        private double Oms(double mrot) => mrot * 0.051 + (SalaryBeforeTax - mrot) * 0.05;
        private double Oss(double mrot) => mrot * 0.029;
        private double Injury() => SalaryBeforeTax * 0.002;
        private double Accounting(double accountingPerYear) => accountingPerYear / 12;
        private void CalculateExpenses(double mrot, double accountingPerYear)
        {
            Expenses = Ndfl() + SalaryAftertax + Ops(mrot) + Oms(mrot) + Oss(mrot) + Injury() + Accounting(accountingPerYear) + ParkingCost;
        }
        private void CalculateProfit()
        {
            Profit = Math.Round(Income - Expenses, 2);
        }
        private void CalculateProfitability()
        {
            ProfitAbility = Math.Round((Income - Expenses) / Income * 100, 2);
        }
        private void CalculateSalaryBeforeTax(double districtCoeff)
        {
            SalaryBeforeTax = Salary + Salary * districtCoeff;
        }
        private void CalculateSalaryAfterTax(double tax)
        {
            SalaryAftertax = SalaryBeforeTax - SalaryBeforeTax * tax;
        }
        public void CalculateMetrics(double districtCoeff, 
            double hoursInMonth,
            double mrot,
            double accountingPerYear,
            double tax)
        {
            CalculateSalary();
            CalculateSalaryBeforeTax(districtCoeff);
            CalculateSalaryAfterTax(tax);
            CalculateIncome(hoursInMonth);
            CalculateExpenses(mrot, accountingPerYear);
            CalculateHourCostFact(hoursInMonth);
            CalculateHourCostHand();
            CalculateProfit();
            CalculateProfitability();
        }
    }
}
