using SalaryCalculation.Domain;
using Salarycalculation.DataAccess.Repositories;

namespace SalaryCalculation.Application.Services.Commands
{
    
    public class SaveCalculatedSalaryMetrics
    {
        private readonly EmployeeSalaryMetricsRepository _employeeSalaryMetricsRepository;

        public SaveCalculatedSalaryMetrics(EmployeeSalaryMetricsRepository employeeSalaryMetricsRepository)
        {
            _employeeSalaryMetricsRepository = employeeSalaryMetricsRepository;
        }

        public void Handle(EmployeeFinancialMetrics salaryMetrics)
        {
            _employeeSalaryMetricsRepository.SaveEmployeeSalaryMetrics(salaryMetrics);
        }
    }
}
