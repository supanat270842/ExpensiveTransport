using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using TransportManagement.Models.db;
using TransportManagement.Models.dbIGuard;
using TransportManagement.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var strCon = builder.Configuration.GetConnectionString("TransportData");
builder.Services.AddDbContext<TransportCCPCPSContext>(option => option.UseSqlServer(strCon));

var strOil = builder.Configuration.GetConnectionString("ApplicationOilData");
builder.Services.AddDbContext<ApplicationOilStationContext>(option => option.UseSqlServer(strOil));

var strIGuard = builder.Configuration.GetConnectionString("IGuardData");
builder.Services.AddDbContext<DataIGuardContext>(option => option.UseSqlServer(strIGuard));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Index/");
    options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Account/ErrorForbidden/");
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("SystemAll", p => p.RequireRole("systemAll"));
    options.AddPolicy("Admin", p => p.RequireRole("admin"));
    options.AddPolicy("User", p => p.RequireRole("user"));  
});

builder.Services.AddNotyf(config=> { config.DurationInSeconds = 10;config.IsDismissable = true;config.Position = NotyfPosition.TopRight; });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseRequestLocalization("en-US");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseNotyf();
app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
