﻿using CollabManage.Data;
using CollabManage.Services;
using CollabManage.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration["ConnectionStrings:CollabManageContext"];

builder.Services.AddDbContext<CollabManageContext>(options => options.
                                   UseMySql(connection,
                                   new MySqlServerVersion(
                                   new Version(8, 0, 2))));

builder.Services.AddScoped<CompanyService>();
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<HomeService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
