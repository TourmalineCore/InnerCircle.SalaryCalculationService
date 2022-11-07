using SalaryCalculation.Domain.Common;

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

        public bool Parking { get; private set; }

        public double ParkingCostPerMonth { get; private set; }

        public double AccountingPerMonth { get; private set; }

        public EmployeeFinancialMetrics(long employeeId, double ratePerHour, double fullSalary, double employmentType, bool parking)
        {
            EmployeeId = employeeId;
            RatePerHour = ratePerHour;
            FullSalary = fullSalary;
            EmploymentType = employmentType;
            Parking = parking;
            ParkingCostPerMonth = parking ? ThirdPartyServicesPriceConsts.ParkingCostPerMonth : 0;
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
            Salary = Math.Round(CalculateSalary(), 2);
            SalaryBeforeTax = Math.Round(CalculateSalaryBeforeTax(districtCoeff));
            SalaryAftertax = Math.Round(CalculateSalaryAfterTax(tax));
            Income = Math.Round(CalculateIncome(),2);
            Expenses = Math.Round(CalculateExpenses(mrot),2);
            HourCostFact = Math.Round(CalculateHourCostFact(),2);
            HourCostHand = Math.Round(CalculateHourCostHand(),2);
            Profit = Math.Round(CalculateProfit(),2);
            ProfitAbility = Math.Round(CalculateProfitability(),2);
        }
    }
}
