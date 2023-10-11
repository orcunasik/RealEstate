using Microsoft.AspNetCore.Mvc;

namespace RealEstate.WebUI.Areas.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
