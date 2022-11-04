using Salarycalculation.DataAccess;
using SalaryCalculation.Application.HelpServices;
using SalaryCalculation.Application.Services.Dtos;
using SalaryCalculation.Domain;

namespace SalaryCalculation.Application.Services
{
    public class SalaryCalculationParams
    {
        public long EmployeeId { get; set; }

        public double RatePerHour { get; set; }

        public double FullSalary { get; set; }

        public double EmploymentType { get; set; }
    }

    public class FinancialMetricsService
    {
        private readonly ITaxDataService _taxDataService;
        private readonly FakeDataBase _fakeDataBase;

        public FinancialMetricsService(ITaxDataService helpService, FakeDataBase fakeDataBase)
        {
            _taxDataService = helpService;
            _fakeDataBase = fakeDataBase;
        }

        public async Task CalculateMetricsAsync(SalaryCalculationParams parameters)
        {
            var employeeFinancialMetrics = new EmployeeFinancialMetrics(parameters.EmployeeId,
                parameters.RatePerHour,
                parameters.FullSalary,
                parameters.EmploymentType);

            var districtCoeff = await _taxDataService.GetChelyabinskDistrictCoeff();
            var personalIncomeTaxPercent = await _taxDataService.GetPersonalIncomeTaxPercent();
            var minimalSizeOfSalary = await _taxDataService.GetMinimalSizeOfSalary();

            employeeFinancialMetrics.CalculateMetrics(districtCoeff, minimalSizeOfSalary, personalIncomeTaxPercent);

            _fakeDataBase.SaveAsync(employeeFinancialMetrics);
        }

        // Move to query
        public Task<EmployeeDto> GetEmployeeMetrics(long empId)
        {
            var empFinancialMetrics = _fakeDataBase.Get(empId);

            if (empFinancialMetrics == null)
            {
                return Task.FromResult(new EmployeeDto());
            }

            return Task.FromResult(
                new EmployeeDto(
                empFinancialMetrics.EmployeeId,
                empFinancialMetrics.Salary,
                empFinancialMetrics.HourCostFact,
                empFinancialMetrics.HourCostHand,
                empFinancialMetrics.Income,
                empFinancialMetrics.Expenses,
                empFinancialMetrics.Profit,
                empFinancialMetrics.ProfitAbility,
                empFinancialMetrics.SalaryBeforeTax,
                empFinancialMetrics.SalaryAftertax
                ));
        }
    }
}
