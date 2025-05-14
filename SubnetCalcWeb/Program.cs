using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SubnetCalcWeb.Services;      // make sure this line ends with a semicolon

var builder = WebApplication.CreateBuilder(args);

// 1) Add MVC
builder.Services.AddControllersWithViews();

// 2) Register your calculator
builder.Services.AddScoped<ISubnetCalculator, SubnetCalculator>();

var app = builder.Build();

// 3) Middleware pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// 4) Route mapping
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Subnet}/{action=Index}/{id?}");

app.Run();
