using SalaryCalculation.Domain;
using Salarycalculation.DataAccess.Repositories;

namespace SalaryCalculation.Application.Services.Commands
{
    public partial class CalculateMetricsCommand
    {
        public SalaryCalculationParams SalaryCalculationParams { get; set; }
    }
    public class CalculateMetricsCommandHandler
    {
        private readonly EmployeeSalaryMetricsRepository _employeeSalaryMetricsRepository;

        public CalculateMetricsCommandHandler(EmployeeSalaryMetricsRepository employeeSalaryMetricsRepository)
        {
            _employeeSalaryMetricsRepository = employeeSalaryMetricsRepository;
        }

        public async Task Handle(CalculateMetricsCommand calculateMetrics)
        {
            _employeeSalaryMetricsRepository.CalculateEmployeeSalaryMetrics(new EmployeeFinancialMetrics(
                calculateMetrics.SalaryCalculationParams.EmployeeId,
                calculateMetrics.SalaryCalculationParams.RatePerHour,
                calculateMetrics.SalaryCalculationParams.FullSalary,
                calculateMetrics.SalaryCalculationParams.EmploymentType,
                calculateMetrics.SalaryCalculationParams.Parking
                ));
        }
    }
}
