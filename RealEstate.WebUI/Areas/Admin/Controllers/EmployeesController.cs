using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate.WebUI.Dtos.EmployeeDtos;

namespace RealEstate.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class EmployeesController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public EmployeesController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7201/api/Employees/");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            List<ResultEmployeeDto> employees = JsonConvert.DeserializeObject<List<ResultEmployeeDto>>(jsonData);
            return View(employees);
        }
        return View();
    }
}
