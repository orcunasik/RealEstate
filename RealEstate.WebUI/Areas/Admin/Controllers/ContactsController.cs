using Microsoft.AspNetCore.Mvc;
using RealEstate.WebUI.ApiClients.Abstracts;

namespace RealEstate.WebUI.Areas.Admin.Controllers;

public class ContactsController : Controller
{
    private readonly IContactApiClient _apiClient;

    public ContactsController(IContactApiClient contactApiClient)
    {
        _apiClient = contactApiClient;
    }

    public IActionResult Index()
    {
        return View();
    }
}
