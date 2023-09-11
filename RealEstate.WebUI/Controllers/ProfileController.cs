using Microsoft.AspNetCore.Mvc;

namespace RealEstate.WebUI.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
