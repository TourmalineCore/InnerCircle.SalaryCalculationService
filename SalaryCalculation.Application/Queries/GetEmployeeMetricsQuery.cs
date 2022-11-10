using SalaryCalculation.Application.Services.Dtos;
using Salarycalculation.DataAccess;


namespace SalaryCalculation.Application.Services.Queries
{
    public partial class GetEmployeeMetricsQuery
    {
        public long EmployeeId { get; set; }
    }
    public class GetEmployeeMetricsQueryHandler
    {
        private readonly FakeDataBase _fakeDataBase;

        public GetEmployeeMetricsQueryHandler(FakeDataBase fakeDataBase)
        {
            _fakeDataBase = fakeDataBase;
        }

        public Task<EmployeeDto> Handle(GetEmployeeMetricsQuery request)
        {
            var empFinancialMetrics = _fakeDataBase.Get(request.EmployeeId);

            if (empFinancialMetrics == null)
            {
                return Task.FromResult(new EmployeeDto());
            }

            return Task.FromResult(
                new EmployeeDto(
                empFinancialMetrics.EmployeeId,
                Math.Round(empFinancialMetrics.Salary,2),
                Math.Round(empFinancialMetrics.HourlyCostFact,2),
                Math.Round(empFinancialMetrics.HourlyCostHand, 2),
                Math.Round(empFinancialMetrics.Earnings, 2),
                Math.Round(empFinancialMetrics.Expenses, 2),
                Math.Round(empFinancialMetrics.Profit, 2),
                Math.Round(empFinancialMetrics.ProfitAbility, 2),
                Math.Round(empFinancialMetrics.GrossSalary, 2),
                Math.Round(empFinancialMetrics.NetSalary, 2),
                Math.Round(empFinancialMetrics.Retainer,2)
                ));
        }
    }

}
