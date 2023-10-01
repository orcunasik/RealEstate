using Microsoft.AspNetCore.Mvc;

namespace RealEstate.WebUI.ViewComponents.Layout;

public class _ScriptViewComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
