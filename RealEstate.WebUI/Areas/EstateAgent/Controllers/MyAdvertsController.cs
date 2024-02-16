using Microsoft.AspNetCore.Mvc;

namespace RealEstate.WebUI.Areas_EstateAgent_Controllers;

[Area("EstateAgent")]
public class MyAdvertsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}