using Microsoft.AspNetCore.Mvc;

namespace RealEstate.WebUI.Controllers;

public class TestController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}