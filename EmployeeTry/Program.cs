using EmployeeTry.Data;
using EmployeeTry.Interface;
using EmployeeTry.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Logging.ClearProviders(); 
builder.Logging.AddConsole();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
});
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();

builder.Services.AddScoped<IEmployee, EmployeeClass>();
builder.Services.AddScoped<AEmployee, EmployeeClass>();

builder.Services.AddDbContext<EmployeeContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeConnectionString")));


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();


app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employee}/{action=Index}/{id?}");

app.Run();
