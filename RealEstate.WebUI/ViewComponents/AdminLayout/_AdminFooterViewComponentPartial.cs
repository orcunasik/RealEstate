using Microsoft.AspNetCore.Mvc;

namespace RealEstate.WebUI.ViewComponents.AdminLayout;

public class _AdminFooterViewComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
