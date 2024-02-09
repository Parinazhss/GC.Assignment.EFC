using ConsoleApp;
using ConsoleApp.Context;
using ConsoleApp.Repositories;
using ConsoleApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{

    services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\projects\GC.Assignment.EFC\ConsoleApp\Data\database.mdf;Integrated Security=True;Connect Timeout=30"));

    services.AddScoped<UserRepository>();
    services.AddScoped<RoleRepository>();
    services.AddScoped<AddressRepository>();
    services.AddScoped<LoanRepository>();
    services.AddScoped<BookRepository>();

    services.AddScoped<UserService>();
    services.AddScoped<RoleService>();
    services.AddScoped<AddressService>();
    services.AddScoped<LoanService>();
    services.AddScoped<BookService>();

    services.AddSingleton<ConsoleUI>();



}).Build();

var consoleUI = builder.Services.GetRequiredService<ConsoleUI>();

//consoleUI.CreateUser_UI();
//consoleUI.GetUsers_UI();
//consoleUI.UpdatedUser_UI();
//consoleUI.DeleteUser_UI();



//consoleUI.CreateLoans_UI();
//consoleUI.GetLoans_UI();
//consoleUI.UpdatedLoans_UI();
consoleUI.DeleteLoan_UI();