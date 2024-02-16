using Microsoft.AspNetCore.Mvc;

namespace RealEstate.WebUI.Areas.EstateAgent.ViewComponents.EstateAgentLayout;

public class _EstateAgentHeaderViewComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}