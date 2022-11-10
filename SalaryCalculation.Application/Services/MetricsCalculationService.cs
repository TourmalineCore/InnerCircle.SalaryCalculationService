using Salarycalculation.DataAccess.HelpServices;
using SalaryCalculation.Application.Services.Commands;
using SalaryCalculation.Domain;

namespace SalaryCalculation.Application.Services
{
    public partial class BasicSalaryMetrics
    {
        public long EmployeeId { get; set; }
        public double RatePerHour { get; set; }
        public double Pay { get; set; }
        public int EmploymentType { get; set; }
        public bool HasParking { get; set; }

    }
    public class MetricsCalculationService
    {
        private readonly ITaxDataService _taxDataService;
        private readonly SaveCalculatedSalaryMetrics _saveCalculatedSalaryMetrics;
        public MetricsCalculationService(ITaxDataService taxDataService, SaveCalculatedSalaryMetrics saveCalculatedSalaryMetrics)
        {
            _taxDataService = taxDataService;
            _saveCalculatedSalaryMetrics = saveCalculatedSalaryMetrics;
        }
        public async Task<long> CalculateMetrics(BasicSalaryMetrics basicSalaryMetrics)
        {
            var salaryMetrics = new EmployeeFinancialMetrics(basicSalaryMetrics.EmployeeId,
                basicSalaryMetrics.RatePerHour,
                basicSalaryMetrics.Pay,
                basicSalaryMetrics.EmploymentType,
                basicSalaryMetrics.HasParking);

            var districtCoeff = await _taxDataService.GetChelyabinskDistrictCoeff();
            var personalIncomeTaxPercent = await _taxDataService.GetPersonalIncomeTaxPercent();
            var minimalSizeOfSalary = await _taxDataService.GetMinimalSizeOfSalary();

            salaryMetrics.CalculateMetrics(districtCoeff, minimalSizeOfSalary, personalIncomeTaxPercent);

            _saveCalculatedSalaryMetrics.Handle(salaryMetrics);
            return salaryMetrics.Id;
        }
    }
}
