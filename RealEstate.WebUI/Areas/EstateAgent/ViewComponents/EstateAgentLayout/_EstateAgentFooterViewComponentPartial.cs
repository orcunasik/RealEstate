using Microsoft.AspNetCore.Mvc;

namespace RealEstate.WebUI.Areas.EstateAgent.ViewComponents.EstateAgentLayout;

public class _EstateAgentFooterViewComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}