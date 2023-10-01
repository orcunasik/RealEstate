using Microsoft.AspNetCore.Mvc;

namespace RealEstate.WebUI.ViewComponents.HomePage;

public class _DefaultSubFeatureViewComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
