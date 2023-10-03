using Microsoft.AspNetCore.Mvc;

namespace RealEstate.WebUI.ViewComponents.HomePage;

public class _DefaultServicesViewComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
