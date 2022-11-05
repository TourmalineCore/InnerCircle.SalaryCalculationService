using SalaryCalculation.Application.Services.Dtos;
using Salarycalculation.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalaryCalculation.Application.HelpServices;

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
                empFinancialMetrics.Salary,
                empFinancialMetrics.HourCostFact,
                empFinancialMetrics.HourCostHand,
                empFinancialMetrics.Income,
                empFinancialMetrics.Expenses,
                empFinancialMetrics.Profit,
                empFinancialMetrics.ProfitAbility,
                empFinancialMetrics.SalaryBeforeTax,
                empFinancialMetrics.SalaryAftertax
                ));
        }
    }

}
