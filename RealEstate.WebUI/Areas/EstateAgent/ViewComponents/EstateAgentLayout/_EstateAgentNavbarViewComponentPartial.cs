using Microsoft.AspNetCore.Mvc;

namespace RealEstate.WebUI.Areas.EstateAgent.ViewComponents.EstateAgentLayout;

public class _EstateAgentNavbarViewComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}