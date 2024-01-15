using Microsoft.AspNetCore.Mvc;
using RealEstate.WebUI.ApiClients.Abstracts;
using RealEstate.WebUI.Dtos.ContactDtos;

namespace RealEstate.WebUI.Areas.Admin.ViewComponents.Dashboard;

public class _DashboardLastContactsViewComponentPartial : ViewComponent
{
    private readonly IContactApiClient _contactApiClient;

    public _DashboardLastContactsViewComponentPartial(IContactApiClient contactApiClient)
    {
        _contactApiClient = contactApiClient;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        List<LastContactResultDto> lastContacts = await _contactApiClient.GetLastContactsAsync();
        return View(lastContacts);
    }
}
