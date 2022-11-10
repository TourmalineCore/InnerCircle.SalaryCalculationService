namespace Salarycalculation.DataAccess.HelpServices
{
    public interface ITaxDataService
    {
        Task<double> GetChelyabinskDistrictCoeff();

        Task<double> GetPersonalIncomeTaxPercent();

        Task<double> GetMinimalSizeOfSalary();
    }
}
