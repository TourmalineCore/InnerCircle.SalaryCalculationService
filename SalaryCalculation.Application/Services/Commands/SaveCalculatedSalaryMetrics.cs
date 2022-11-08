using SalaryCalculation.Domain;
using Salarycalculation.DataAccess.Repositories;

namespace SalaryCalculation.Application.Services.Commands
{
    public enum EmploymentType
    {
        Fulltime,
        PartTime
    }
    public partial class BasicSalaryMetrics
    {
        public long EmployeeId { get; set; }
        public double RatePerHour { get; set; }
        public double FullSalary { get; set; }
        public EmploymentType EmploymentType { get; set; }
        public double EmploymentTypeValue { get; set; }
        public bool HasParking { get; set; }

        public BasicSalaryMetrics() { }

        public BasicSalaryMetrics(long employeeId, double ratePerHour, double fullSalary, EmploymentType employmentType, bool hasParking)
        {
            EmployeeId = employeeId;
            RatePerHour = ratePerHour;
            FullSalary = fullSalary;
            EmploymentType = employmentType;
            switch (employmentType)
            {
                case EmploymentType.Fulltime:
                    EmploymentTypeValue = 1.0;
                    break;
                case EmploymentType.PartTime:
                    EmploymentTypeValue = 0.5;
                    break;
            }
            HasParking = hasParking;
        }
    }
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
