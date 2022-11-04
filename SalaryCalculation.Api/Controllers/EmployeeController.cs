using Microsoft.AspNetCore.Mvc;
using SalaryCalculation.Api.Controllers.RequestModels;
using SalaryCalculation.Application.Services;
using SalaryCalculation.Application.Services.Dtos;

namespace SalaryCalculation.Api.Controllers
{
    [Route("api/employee")]
    public class EmployeeController : Controller
    {
        private readonly FinancialMetricsService _salaryService;

        public EmployeeController(FinancialMetricsService salaryService)
        {
            _salaryService = salaryService;
        }

        [HttpPost("calculate-financial-metrics")]
        public Task CalculateMetrics([FromBody] EmployeeSalaryDataRequest employeeSalaryDataRequest)
        {
            var employeeId = 1;
            var ratePerHour = 400.00;
            var fullSalary = 20000.00;
            var employmentType = 1.0;

            employeeSalaryDataRequest = new EmployeeSalaryDataRequest(employeeId, ratePerHour, fullSalary, employmentType);

            return _salaryService.CalculateMetricsAsync(new SalaryCalculationParams
            {
                EmployeeId = employeeSalaryDataRequest.EmployeeId,
                RatePerHour = employeeSalaryDataRequest.RatePerHour,
                FullSalary = employeeSalaryDataRequest.FullSalary,
                EmploymentType = employeeSalaryDataRequest.EmploymentType,
            });
        }

        [HttpGet("findById/{empId}")]
        public Task<EmployeeDto> GetMetrics([FromRoute] long empId)
        {
            return _salaryService.GetEmployeeMetrics(empId);
        }
    }
}
