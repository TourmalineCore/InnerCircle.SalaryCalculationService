using Salarycalculation.DataAccess;
using SalaryCalculation.Application;
using SalaryCalculation.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<FinancialMetricsService>();
builder.Services.AddControllers();

builder.Services.AddApplication();
builder.Services.AddPersistence();

var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.Run();
