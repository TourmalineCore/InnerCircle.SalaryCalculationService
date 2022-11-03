using SalaryCalculation.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<SalaryService>();
builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.Run();
