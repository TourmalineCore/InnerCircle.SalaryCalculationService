using Salarycalculation.DataAccess.HelpServices;
using SalaryCalculation.Application.Services.Commands;
using SalaryCalculation.Domain;

namespace SalaryCalculation.Application.Services
{
    public class MetricsCalculationService
    {
        private readonly ITaxDataService _taxDataService;
        private readonly SaveCalculatedSalaryMetrics _calculateMetricsCommandHandler;
        public MetricsCalculationService(ITaxDataService taxDataService, SaveCalculatedSalaryMetrics calculateMetricsCommandHandler)
        {
            _taxDataService = taxDataService;
            _calculateMetricsCommandHandler = calculateMetricsCommandHandler;
        }

        public async Task<EmployeeFinancialMetrics> CalculateMetrics(BasicSalaryMetrics calculateMetricsCommand)
        {
            var salaryMetrics = new EmployeeFinancialMetrics(calculateMetricsCommand.EmployeeId,
                calculateMetricsCommand.RatePerHour,
                calculateMetricsCommand.FullSalary,
                calculateMetricsCommand.EmploymentTypeValue,
                calculateMetricsCommand.HasParking);

            var districtCoeff = await _taxDataService.GetChelyabinskDistrictCoeff();
            var personalIncomeTaxPercent = await _taxDataService.GetPersonalIncomeTaxPercent();
            var minimalSizeOfSalary = await _taxDataService.GetMinimalSizeOfSalary();

            salaryMetrics.CalculateMetrics(districtCoeff, minimalSizeOfSalary, personalIncomeTaxPercent);

            _calculateMetricsCommandHandler.Handle(salaryMetrics);
            return salaryMetrics;
        }
    }
}
