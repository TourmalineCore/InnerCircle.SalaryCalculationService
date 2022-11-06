using SalaryCalculation.Application.HelpServices;
using Salarycalculation.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalaryCalculation.Domain;

namespace SalaryCalculation.Application.Services.Commands
{
    public partial class CalculateMetricsCommand
    {
        public SalaryCalculationParams SalaryCalculationParams { get; set; }
    }
    public class CalculateMetricsCommandHandler
    {
        private readonly ITaxDataService _taxDataService;
        private readonly FakeDataBase _fakeDataBase;

        public CalculateMetricsCommandHandler(ITaxDataService helpService, FakeDataBase fakeDataBase)
        {
            _taxDataService = helpService;
            _fakeDataBase = fakeDataBase;
        }

        public async Task Handle(CalculateMetricsCommand CalculateMetrics)
        {
            var employeeFinancialMetrics = new EmployeeFinancialMetrics(CalculateMetrics.SalaryCalculationParams.EmployeeId,
                CalculateMetrics.SalaryCalculationParams.RatePerHour,
                CalculateMetrics.SalaryCalculationParams.FullSalary,
                CalculateMetrics.SalaryCalculationParams.EmploymentType,
                CalculateMetrics.SalaryCalculationParams.Parking);

            var districtCoeff = await _taxDataService.GetChelyabinskDistrictCoeff();
            var personalIncomeTaxPercent = await _taxDataService.GetPersonalIncomeTaxPercent();
            var minimalSizeOfSalary = await _taxDataService.GetMinimalSizeOfSalary();

            employeeFinancialMetrics.CalculateMetrics(districtCoeff, minimalSizeOfSalary, personalIncomeTaxPercent);

            _fakeDataBase.SaveAsync(employeeFinancialMetrics);
        }
    }
}
