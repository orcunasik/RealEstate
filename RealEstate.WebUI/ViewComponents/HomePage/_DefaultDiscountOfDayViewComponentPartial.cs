using Microsoft.AspNetCore.Mvc;

namespace RealEstate.WebUI.ViewComponents.HomePage;

public class _DefaultDiscountOfDayViewComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
