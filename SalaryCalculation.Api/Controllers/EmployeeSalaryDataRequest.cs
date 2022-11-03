namespace SalaryCalculation.Api.Controllers
{
    public class EmployeeSalaryDataRequest
    {
        public int Id { get; set; }
        public double RatePerHour { get; set; }
        public double FullSalary { get; set; }
        public double EmploymentType { get; set; }
        public double ParkingCost { get; set; }

        public EmployeeSalaryDataRequest() { }

        public EmployeeSalaryDataRequest(int id, double ratePerHour, double fullSalary, double employmentType, double parkingCost)
        {
            Id = id;
            RatePerHour = ratePerHour;
            FullSalary = fullSalary;
            EmploymentType = employmentType;
            ParkingCost = parkingCost;
        }
    }
}
