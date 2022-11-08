using SalaryCalculation.Domain;
using Salarycalculation.DataAccess.Repositories;
using Salarycalculation.DataAccess.HelpServices;

namespace SalaryCalculation.Application.Services.Commands
{
    public partial class CalculateMetricsCommand
    {
        public long EmployeeId { get; set; }
        public double RatePerHour { get; set; }
        public double FullSalary { get; set; }
        public double EmploymentType { get; set; }
        public bool Parking { get; set; }
    }
    public class CalculateMetricsCommandHandler
    {
        private readonly EmployeeSalaryMetricsRepository _employeeSalaryMetricsRepository;
        private readonly ITaxDataService _taxDataService;

        public CalculateMetricsCommandHandler(ITaxDataService taxDataService, EmployeeSalaryMetricsRepository employeeSalaryMetricsRepository)
        {
            _employeeSalaryMetricsRepository = employeeSalaryMetricsRepository;
            _taxDataService = taxDataService;
        }

        public async Task Handle(CalculateMetricsCommand calculateMetrics)
        {
            var districtCoeff = await _taxDataService.GetChelyabinskDistrictCoeff();
            var personalIncomeTaxPercent = await _taxDataService.GetPersonalIncomeTaxPercent();
            var minimalSizeOfSalary = await _taxDataService.GetMinimalSizeOfSalary();
            EmployeeFinancialMetrics salaryMetrics = new EmployeeFinancialMetrics(calculateMetrics.EmployeeId, 
                calculateMetrics.RatePerHour, 
                calculateMetrics.FullSalary, 
                calculateMetrics.EmploymentType, 
                calculateMetrics.Parking);

            salaryMetrics.CalculateMetrics(districtCoeff, minimalSizeOfSalary, personalIncomeTaxPercent);

            _employeeSalaryMetricsRepository.SaveEmployeeSalaryMetrics(salaryMetrics);
        }
    }
}
