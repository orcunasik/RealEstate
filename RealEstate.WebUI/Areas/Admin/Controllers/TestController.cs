using Microsoft.AspNetCore.Mvc;

namespace RealEstate.WebUI.Areas.Admin.Controllers;

public class TestController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}