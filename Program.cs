using MeasurementApp.Data;
using MeasurementApp.Repositories;
using MeasurementApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuração da string de conexão para o banco de dados Oracle
var connectionString = builder.Configuration.GetConnectionString("OracleDbConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'OracleDbConnection' is missing or empty.");
}
Console.WriteLine($"Using connection string: {connectionString}");

// Configuração do DbContext para uso do Oracle
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(connectionString));

// Configuração do repositório genérico
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// Configuração do serviço MeasurementService
builder.Services.AddScoped<MeasurementService>();

// Configuração do SignalR
builder.Services.AddSignalR();

// Adiciona suporte para controladores e views (MVC)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurações de ambiente
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Configuração das rotas
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();