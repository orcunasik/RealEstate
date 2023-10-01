using Microsoft.AspNetCore.Mvc;

namespace RealEstate.WebUI.ViewComponents.HomePage;

public class _DefaultBrandsViewComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
