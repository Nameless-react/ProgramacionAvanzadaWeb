using Frontend.Helpers.Implementations;
using Frontend.Helpers.Interface;
using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<IServiceRepository, ServiceRepository>(); 
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IEmployeeHelper, EmployeeHelper>();
builder.Services.AddScoped<IClientHelper, ClientHelper>();
builder.Services.AddScoped<IAccountHelper, AccountHelper>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
