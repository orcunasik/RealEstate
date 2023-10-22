using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate.WebUI.Dtos.CategoryDtos;
using System.Text;

namespace RealEstate.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class CategoriesController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public CategoriesController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IActionResult> Index()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7201/api/Categories/");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            List<ResultCategoryDto> values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            return View(values);
        }
        return View();
    }

    [HttpGet]
    public IActionResult CreateCategory()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryDto categoryDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(categoryDto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PostAsync("https://localhost:7201/api/Categories/", stringContent);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index");
        return View();
    }

    public async Task<IActionResult> DeleteCategory(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.DeleteAsync($"https://localhost:7201/api/Categories/{id}");
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index");
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> UpdateCategory(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync($"https://localhost:7201/api/Categories/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            UpdateCategoryDto values = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
            return View(values);
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryDto categoryDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(categoryDto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PutAsync("https://localhost:7201/api/Categories/", stringContent);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index");
        return View();
    }
}
