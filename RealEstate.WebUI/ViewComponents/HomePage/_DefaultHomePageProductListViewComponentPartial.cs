using Microsoft.AspNetCore.Mvc;

namespace RealEstate.WebUI.ViewComponents.HomePage;

public class _DefaultHomePageProductListViewComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
