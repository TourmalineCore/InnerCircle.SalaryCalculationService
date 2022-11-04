namespace SalaryCalculation.Api.Controllers.RequestModels
{
    public class EmployeeSalaryDataRequest
    {
        public long EmployeeId { get; set; }
        public double RatePerHour { get; set; }
        public double FullSalary { get; set; }
        public double EmploymentType { get; set; }

        public EmployeeSalaryDataRequest() { }

        public EmployeeSalaryDataRequest(int employeeId, double ratePerHour, double fullSalary, double employmentType)
        {
            EmployeeId = employeeId;
            RatePerHour = ratePerHour;
            FullSalary = fullSalary;
            EmploymentType = employmentType;
        }
    }
}
