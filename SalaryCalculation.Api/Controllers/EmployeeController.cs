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
        public Task CalculateMetrics([FromBody] BasicSalaryMetrics employeeSalaryDataRequest)
        {
            var employeeId = 1;
            var ratePerHour = 400.00;
            var fullSalary = 20000.00;
            var employmentType = EmploymentType.Fulltime;
            var hasParking = true;

            employeeSalaryDataRequest = new BasicSalaryMetrics(employeeId, ratePerHour, fullSalary, employmentType, hasParking);
            return _metricsCalculationService.CalculateMetrics(new BasicSalaryMetrics()
            {
                EmployeeId = employeeSalaryDataRequest.EmployeeId,
                RatePerHour = employeeSalaryDataRequest.RatePerHour,
                FullSalary = employeeSalaryDataRequest.FullSalary,
                EmploymentTypeValue = employeeSalaryDataRequest.EmploymentTypeValue,
                HasParking = employeeSalaryDataRequest.HasParking
            });
        }

        [HttpGet("findById/{EmployeeId}")]
        public Task<EmployeeDto> GetMetrics([FromRoute] GetEmployeeMetricsQuery getEmployeeMetricsQuery)
        {
            return _getEmployeeMetricsQueryHandler.Handle(getEmployeeMetricsQuery);
        }
    }
}
