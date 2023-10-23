using Microsoft.AspNetCore.Mvc;

namespace RealEstate.WebUI.Areas.Admin.ViewComponents.AdminLayout;

public class _AdminSpinnerViewComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
