using Microsoft.AspNetCore.Mvc;

namespace RealEstate.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
