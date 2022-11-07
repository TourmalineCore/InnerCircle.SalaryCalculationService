using Microsoft.AspNetCore.Mvc;
using SalaryCalculation.Api.Controllers.RequestModels;
using SalaryCalculation.Application.Services;
using SalaryCalculation.Application.Services.Commands;
using SalaryCalculation.Application.Services.Dtos;
using SalaryCalculation.Application.Services.Queries;

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
            var employmentType = EmploymentType.Fulltime;
            var parking = true;

            employeeSalaryDataRequest = new EmployeeSalaryDataRequest(employeeId, ratePerHour, fullSalary, employmentType, parking);

            CalculateMetricsCommand calculate = new CalculateMetricsCommand();

            calculate.SalaryCalculationParams = new SalaryCalculationParams
            {
                EmployeeId = employeeSalaryDataRequest.EmployeeId,
                RatePerHour = employeeSalaryDataRequest.RatePerHour,
                FullSalary = employeeSalaryDataRequest.FullSalary,
                EmploymentType = employeeSalaryDataRequest.EmploymentTypeValue,
                Parking = employeeSalaryDataRequest.Parking
            };
            return _salaryService.CalculateMetricsAsync(calculate);
        }

        [HttpGet("findById/{empId}")]
        public Task<EmployeeDto> GetMetrics([FromRoute] long empId)
        {
            GetEmployeeMetricsQuery getEmployeeMetricsQuery = new GetEmployeeMetricsQuery();
            getEmployeeMetricsQuery.EmployeeId = empId;
            return _salaryService.GetEmployeeMetrics(getEmployeeMetricsQuery);
        }
    }
}
