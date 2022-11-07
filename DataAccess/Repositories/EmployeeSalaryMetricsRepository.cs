using Salarycalculation.DataAccess.HelpServices;
using SalaryCalculation.Domain;

namespace Salarycalculation.DataAccess.Repositories
{
    public class EmployeeSalaryMetricsRepository
    {
        private readonly ITaxDataService _taxDataService;
        private readonly FakeDataBase _fakeDataBase;

        public EmployeeSalaryMetricsRepository(ITaxDataService taxDataService, FakeDataBase fakeDataBase)
        {
            _taxDataService = taxDataService;
            _fakeDataBase = fakeDataBase;
        }
        public async void CalculateEmployeeSalaryMetrics(EmployeeFinancialMetrics calculateMetrics)
        {
            var districtCoeff = await _taxDataService.GetChelyabinskDistrictCoeff();
            var personalIncomeTaxPercent = await _taxDataService.GetPersonalIncomeTaxPercent();
            var minimalSizeOfSalary = await _taxDataService.GetMinimalSizeOfSalary();

            calculateMetrics.CalculateMetrics(districtCoeff, minimalSizeOfSalary, personalIncomeTaxPercent);

            _fakeDataBase.SaveAsync(calculateMetrics);
        }
    }
}
