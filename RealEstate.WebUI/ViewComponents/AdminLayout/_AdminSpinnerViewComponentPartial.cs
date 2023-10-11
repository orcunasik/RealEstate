using Microsoft.AspNetCore.Mvc;

namespace RealEstate.WebUI.ViewComponents.AdminLayout;

public class _AdminSpinnerViewComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
