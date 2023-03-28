
using System.Diagnostics;
using System.Security.Claims;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using TransportManagement.Models;
using TransportManagement.Models.db;
using TransportManagement.Services;
using Microsoft.EntityFrameworkCore;

namespace TransportManagement.Controllers;

public class AccountController : Controller
{
    private readonly INotyfService _notfy;
    private TransportCCPCPSContext _db;

    public AccountController(TransportCCPCPSContext db, INotyfService notyf)
    {
        _notfy = notyf;
        _db = db;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult ErrorForbidden()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginModel data)
    {      
            try
            {
                bool IsAuth = false;
                ClaimsIdentity claim = null;
                string _role = string.Empty;
                var result = await NetworkService.StdLogin(data.UserName, data.Password, "WB2022-135");

                if (result.autoID != 0)
                {

                    if (result == null)
                    {
                        _role = "display";
                    }
                    else
                    {
                        _role = data.UserName;
                    }              

                    claim = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Name, result.name + " " + result.surname),
                        new Claim(ClaimTypes.Role, "Admin"),
                    }, CookieAuthenticationDefaults.AuthenticationScheme);
                    IsAuth = true;
                }
                if (IsAuth)
                {
                    var principal = new ClaimsPrincipal(claim);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    _notfy.Error("UserName หรือ Password ผิด ไม่สามารถเข้าได้");
                }
            }
            catch (Exception ex)
            {
                _notfy.Error(ex.Message);
            }

        return View(data);
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction(nameof(Index));
    }

}