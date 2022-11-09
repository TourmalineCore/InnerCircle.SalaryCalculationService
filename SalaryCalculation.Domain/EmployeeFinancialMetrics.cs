using SalaryCalculation.Domain.Common;

namespace SalaryCalculation.Domain
{
    public class EmployeeFinancialMetrics
    {
        public long Id { get; private set; }

        public long EmployeeId { get; private set; }

        private double salary;

        public double Salary { get { return salary; } private set { if (value >= 0) salary = value; else throw new ArgumentException(); } }

        private double hourCostFact;
        public double HourCostFact { get { return hourCostFact; } private set { if (value >= 0) hourCostFact = value; else throw new ArgumentException(); } }

        private double hourCostHand;

        public double HourCostHand { get { return hourCostHand; } private set { if (value >= 0) hourCostHand = value; else throw new ArgumentException(); } }

        private double income;

        public double Income { get { return income; } private set { if (value >= 0) income = value; else throw new ArgumentException(); } }

        private double expenses;

        public double Expenses { get { return expenses; } private set { if (value >= 0) expenses = value; else throw new ArgumentException(); } }

        private double profit;

        public double Profit { get { return profit; } private set { if (value >= 0) profit = value; else throw new ArgumentException(); } }

        private double profitability;

        public double ProfitAbility { get { return profitability; } private set { if (value >= 0) profitability = value; else throw new ArgumentException(); } }

        private double salaryBeforeTax;

        public double SalaryBeforeTax { get { return salaryBeforeTax; } private set { if (value >= 0) salaryBeforeTax = value; else throw new ArgumentException(); } }

        private double salaryAfterTax;

        public double SalaryAftertax { get { return salaryAfterTax; } private set { if (value >= 0) salaryAfterTax = value; else throw new ArgumentException(); } }

        private double ratePerHour;

        public double RatePerHour { get { return ratePerHour; } private set { if (value >= 0) ratePerHour = value; else throw new ArgumentException(); } }

        private double fullSalary;

        public double FullSalary { get { return fullSalary; } private set { if (value >= 0) fullSalary = value; else throw new ArgumentException(); } }

        public double EmploymentType { get; private set; }

        public bool HasParking { get; private set; }

        public double ParkingCostPerMonth { get; private set; }

        public double AccountingPerMonth { get; private set; }

        public EmployeeFinancialMetrics(long employeeId, double ratePerHour, double fullSalary, double employmentType, bool hasParking)
        {
            EmployeeId = employeeId;
            RatePerHour = ratePerHour;
            FullSalary = fullSalary;
            EmploymentType = employmentType;
            HasParking = hasParking;
            ParkingCostPerMonth = hasParking ? ThirdPartyServicesPriceConsts.ParkingCostPerMonth : 0;
            AccountingPerMonth = ThirdPartyServicesPriceConsts.AccountingPerMonth;
        }


        private double CalculateHourCostFact()
        {
            return Expenses / WorkingPlanConsts.WorkingHoursInMonth;
        }

        private double CalculateHourCostHand()
        {
            return Salary / 160;
        }

        private double CalculateIncome()
        {
            return RatePerHour * WorkingPlanConsts.WorkingHoursInMonth * EmploymentType;
        }

        private double CalculateExpenses(double mrot)
        {
            return GetNdflValue() +
                SalaryAftertax + 
                GetPensionContributions(mrot) + 
                GetMedicalContributions(mrot) + 
                GetSocialInsuranceContributions(mrot) +
                GetInjuriesContributions() +
                AccountingPerMonth +
                ParkingCostPerMonth;
        }

        private double GetNdflValue()
        {
            return SalaryBeforeTax * 0.13;
        }

        private double GetPensionContributions(double mrot)
        {
            return mrot * 0.22 + (SalaryBeforeTax - mrot) * 0.1;
        }

        private double GetMedicalContributions(double mrot)
        {
            return mrot * 0.051 + (SalaryBeforeTax - mrot) * 0.05;
        }

        private double GetSocialInsuranceContributions(double mrot)
        {
            return mrot * 0.029;
        }

        private double GetInjuriesContributions()
        {
            return SalaryBeforeTax * 0.002;
        }

        private double CalculateProfit()
        {
            return Income - Expenses;
        }

        private double CalculateProfitability()
        {
            return (Income - Expenses) / Income * 100;
        }

        private double CalculateSalaryBeforeTax(double districtCoeff)
        {
           return Salary + Salary * districtCoeff;
        }

        private double CalculateSalaryAfterTax(double tax)
        {
            return SalaryBeforeTax - SalaryBeforeTax * tax;
        }

        private double CalculateSalary()
        {
            return FullSalary * EmploymentType;
        }

        public void CalculateMetrics(double districtCoeff,
            double mrot,
            double tax)
        {
            Salary = CalculateSalary();
            SalaryBeforeTax = CalculateSalaryBeforeTax(districtCoeff);
            SalaryAftertax = CalculateSalaryAfterTax(tax);
            Income = CalculateIncome();
            Expenses = CalculateExpenses(mrot);
            HourCostFact = CalculateHourCostFact();
            HourCostHand = CalculateHourCostHand();
            Profit = CalculateProfit();
            ProfitAbility = CalculateProfitability();
        }
    }
}
