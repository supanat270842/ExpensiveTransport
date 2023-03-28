using System.Diagnostics;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TransportManagement.Models;

namespace TransportManagement.Controllers;
[Authorize]
public class ErrorController : BaseController
{
    private readonly INotyfService _notyf;
    public ErrorController(INotyfService notyf)
    {
        _notyf = notyf;
    }
    public async Task<IActionResult> Index(string result)
    {
        ViewBag.ErrorData = "DataBase มีปัญหากรุณาติดต่อแผนก IT " + result;
        return View();
    }

}
