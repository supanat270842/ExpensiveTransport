using System.Diagnostics;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TransportManagement.Models;

namespace TransportManagement.Controllers;
[Authorize]
public class HomeController : BaseController
{
    private readonly INotyfService _notyf;
    public HomeController(INotyfService notyf)
    {
        _notyf = notyf;
    }
    public IActionResult Index()
    {
        if (User.Identity.IsAuthenticated)
        {
            _notyf.Success("ยินดีต้อนรับคุณ " + User.Identity.Name);

        }
        return View();
    }

}
