using Salarycalculation.DataAccess;
using SalaryCalculation.Application.HelpServices;
using SalaryCalculation.Application.Services.Commands;
using SalaryCalculation.Application.Services.Dtos;
using SalaryCalculation.Application.Services.Queries;
using SalaryCalculation.Domain;

namespace SalaryCalculation.Application.Services
{
    public partial class SalaryCalculationParams
    {
        public long EmployeeId { get; set; }

        public double RatePerHour { get; set; }

        public double FullSalary { get; set; }

        public double EmploymentType { get; set; }
        public bool Parking { get; set; }
    }

    public class FinancialMetricsService
    {
        private readonly GetEmployeeMetricsQueryHandler _getEmployeeMetricsQueryHandler;

        private readonly CalculateMetricsCommandHandler _calculateMetricsCommandHandler;

        public FinancialMetricsService(GetEmployeeMetricsQueryHandler getEmployeeMetricsQueryHandler,
            CalculateMetricsCommandHandler calculateMetricsCommandHandler)
        {
            _getEmployeeMetricsQueryHandler = getEmployeeMetricsQueryHandler;
            _calculateMetricsCommandHandler = calculateMetricsCommandHandler;
        }

        public async Task CalculateMetricsAsync(CalculateMetricsCommand calculateMetricsCommand)
        {
            await _calculateMetricsCommandHandler.Handle(calculateMetricsCommand);
        }

        public Task<EmployeeDto> GetEmployeeMetrics(GetEmployeeMetricsQuery getEmployeeMetricsQuery)
        {
            return _getEmployeeMetricsQueryHandler.Handle(getEmployeeMetricsQuery);
        }
    }
}
