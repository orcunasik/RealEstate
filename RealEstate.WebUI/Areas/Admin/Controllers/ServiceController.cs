using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate.WebUI.Dtos.ServiceDtos;
using System.Text;

namespace RealEstate.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class ServiceController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ServiceController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IActionResult> Index()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7201/api/Services/");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            List<ResultServiceDto> services = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
            return View(services);
        }
        return View();
    }

    [HttpGet]
    public IActionResult CreateService()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateService(CreateServiceDto serviceDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(serviceDto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PostAsync("https://localhost:7201/api/Services/", stringContent);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index");
        return View();
    }

    public async Task<IActionResult> DeleteService(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.DeleteAsync($"https://localhost:7201/api/Services/{id}");
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index");
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> UpdateService(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync($"https://localhost:7201/api/Services/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            UpdateServiceDto result = JsonConvert.DeserializeObject<UpdateServiceDto>(jsonData);
            return View(result);
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateService(UpdateServiceDto serviceDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(serviceDto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PutAsync("https://localhost:7201/api/Services/", stringContent);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index");
        return View();
    }
}
