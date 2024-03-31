using DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Session;
using NToastNotify;
using System;
using DoAnMonPhanTichPhanMem.Areas.GiamDoc.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews()
    .AddNToastNotifyToastr(new ToastrOptions()
    {
        PositionClass = ToastPositions.TopRight,
        TimeOut = 4000
    });
builder.Services.AddDbContext<QuanLyCoSoVatChatContext>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(3600);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
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
app.UseNToastNotify();
app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
	  name: "areas",
	  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
	);

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
