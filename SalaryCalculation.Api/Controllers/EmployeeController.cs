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
            var pay = 20000.00;
            var employmentType = EmploymentType.Fulltime;
            var hasParking = true;

            employeeSalaryDataRequest = new BasicSalaryMetrics(employeeId, ratePerHour, pay, employmentType, hasParking);
            return _metricsCalculationService.CalculateMetrics(new BasicSalaryMetrics()
            {
                EmployeeId = employeeSalaryDataRequest.EmployeeId,
                RatePerHour = employeeSalaryDataRequest.RatePerHour,
                Pay = employeeSalaryDataRequest.Pay,
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
