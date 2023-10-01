using Microsoft.AspNetCore.Mvc;

namespace RealEstate.WebUI.ViewComponents.Layout;

public class _FooterViewComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
