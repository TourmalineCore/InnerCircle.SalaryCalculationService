using Microsoft.AspNetCore.Mvc;
using SalaryCalculation.Application;

namespace SalaryCalculation.Api.Controllers
{
    [Route("api/employee")]
    public class EmployeeController : Controller
    {
        private readonly SalaryService _salaryService;

        public EmployeeController(SalaryService salaryService)
        {
            _salaryService = salaryService;
        }

        [HttpGet("salary")]
        public EmployeeDto GetSalaryCalculations(EmployeeSalaryDataRequest employeeSalaryDataRequest)
        {
            employeeSalaryDataRequest = new EmployeeSalaryDataRequest(1, 400, 20000, 1, 1800);
            return _salaryService.Calculate(new SalaryCalculationParams
            {
                Id = employeeSalaryDataRequest.Id,
                RatePerHour = employeeSalaryDataRequest.RatePerHour,
                FullSalary = employeeSalaryDataRequest.FullSalary,
                EmploymentType = employeeSalaryDataRequest.EmploymentType,
                ParkingCost = employeeSalaryDataRequest.ParkingCost
            });
        }
    }
}
