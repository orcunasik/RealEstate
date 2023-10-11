using Microsoft.AspNetCore.Mvc;

namespace RealEstate.WebUI.ViewComponents.AdminLayout;

public class _AdminHeaderViewComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
