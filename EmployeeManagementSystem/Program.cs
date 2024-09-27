using EmployeeManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Add support for API Controllers.
builder.Services.AddControllers();


builder.Services.AddDbContext<EmployeeContext>(options =>
    options.UseInMemoryDatabase("EmployeeDb"));
//builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();
// Map API Controllers
app.MapControllers();
app.Run();
