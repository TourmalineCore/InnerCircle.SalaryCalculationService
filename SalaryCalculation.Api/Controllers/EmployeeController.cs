using Microsoft.AspNetCore.Mvc;
using SalaryCalculation.Application.Services;
using SalaryCalculation.Application.Services.Commands;
using SalaryCalculation.Application.Services.Dtos;
using SalaryCalculation.Application.Services.Queries;

namespace SalaryCalculation.Api.Controllers
{
    [Route("api/employee")]
    public class EmployeeController : Controller
    {
        private readonly GetEmployeeMetricsQueryHandler _getEmployeeMetricsQueryHandler;

        private readonly MetricsCalculationService _metricsCalculationService;

        public EmployeeController(GetEmployeeMetricsQueryHandler getEmployeeMetricsQueryHandler,
            MetricsCalculationService metricsCalculationService)
        {
            _getEmployeeMetricsQueryHandler = getEmployeeMetricsQueryHandler;
            _metricsCalculationService = metricsCalculationService;
        }

        [HttpPost("calculate-financial-metrics")]
        public Task<long> CalculateMetrics([FromBody] BasicSalaryMetrics basicSalaryMetrics)
        {
            return _metricsCalculationService.CalculateMetrics(basicSalaryMetrics);
        }

        [HttpGet("findById/{EmployeeId}")]
        public Task<EmployeeDto> GetMetrics([FromRoute] GetEmployeeMetricsQuery getEmployeeMetricsQuery)
        {
            return _getEmployeeMetricsQueryHandler.Handle(getEmployeeMetricsQuery);
        }
    }
}
