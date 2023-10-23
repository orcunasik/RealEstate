using Microsoft.AspNetCore.Mvc;

namespace RealEstate.WebUI.Areas.Admin.ViewComponents.AdminLayout;

public class _AdminFooterViewComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
