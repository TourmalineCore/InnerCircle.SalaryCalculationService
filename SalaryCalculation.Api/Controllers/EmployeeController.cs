using Microsoft.AspNetCore.Mvc;
using SalaryCalculation.Api.Controllers.RequestModels;
using SalaryCalculation.Application.Services.Commands;
using SalaryCalculation.Application.Services.Dtos;
using SalaryCalculation.Application.Services.Queries;

namespace SalaryCalculation.Api.Controllers
{
    [Route("api/employee")]
    public class EmployeeController : Controller
    {
        private readonly GetEmployeeMetricsQueryHandler _getEmployeeMetricsQueryHandler;

        private readonly CalculateMetricsCommandHandler _calculateMetricsCommandHandler;

        public EmployeeController(GetEmployeeMetricsQueryHandler getEmployeeMetricsQueryHandler,
            CalculateMetricsCommandHandler calculateMetricsCommandHandler)
        {
            _getEmployeeMetricsQueryHandler = getEmployeeMetricsQueryHandler;
            _calculateMetricsCommandHandler = calculateMetricsCommandHandler;
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
            return _calculateMetricsCommandHandler.Handle(new CalculateMetricsCommand()
            {
                EmployeeId = employeeSalaryDataRequest.EmployeeId,
                RatePerHour = employeeSalaryDataRequest.RatePerHour,
                FullSalary = employeeSalaryDataRequest.FullSalary,
                EmploymentType = employeeSalaryDataRequest.EmploymentTypeValue,
                Parking = employeeSalaryDataRequest.Parking
            });
        }

        [HttpGet("findById/{empId}")]
        public Task<EmployeeDto> GetMetrics([FromRoute] long empId)
        {
            GetEmployeeMetricsQuery getEmployeeMetricsQuery = new GetEmployeeMetricsQuery();
            getEmployeeMetricsQuery.EmployeeId = empId;
            return _getEmployeeMetricsQueryHandler.Handle(getEmployeeMetricsQuery);
        }
    }
}
