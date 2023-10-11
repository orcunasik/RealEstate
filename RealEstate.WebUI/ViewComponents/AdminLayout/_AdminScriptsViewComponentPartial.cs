using Microsoft.AspNetCore.Mvc;

namespace RealEstate.WebUI.ViewComponents.AdminLayout;

public class _AdminScriptsViewComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
