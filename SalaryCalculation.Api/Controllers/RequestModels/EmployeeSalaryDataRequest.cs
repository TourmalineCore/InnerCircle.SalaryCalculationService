namespace SalaryCalculation.Api.Controllers.RequestModels
{
    public enum EmploymentType
    {
        Fulltime, 
        PartTime
    }
    public class EmployeeSalaryDataRequest
    {
        public long EmployeeId { get; set; }
        public double RatePerHour { get; set; }
        public double FullSalary { get; set; }
        public EmploymentType EmploymentType { get; set; }
        public double EmploymentTypeValue { get; set; }
        public bool Parking { get; set; }

        public EmployeeSalaryDataRequest() { }

        public EmployeeSalaryDataRequest(long employeeId, double ratePerHour, double fullSalary, EmploymentType employmentType, bool parking)
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
            Parking = parking;
        }
    }
}
