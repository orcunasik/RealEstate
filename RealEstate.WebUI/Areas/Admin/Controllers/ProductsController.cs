using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RealEstate.WebUI.ApiClients.Abstracts;
using RealEstate.WebUI.Dtos.CategoryDtos;
using RealEstate.WebUI.Dtos.ProductDtos;

namespace RealEstate.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class ProductsController : Controller
{
    private readonly IProductApiClient _apiClient;
    private readonly IHttpClientFactory _httpClientFactory;
    public ProductsController(IProductApiClient apiClient, IHttpClientFactory httpClientFactory)
    {
        _apiClient = apiClient;
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IActionResult> Index()
    {
        List<ResultProductWithCategoryDto> products = await _apiClient.GetAllProductWithCategoryAsync();
        return View(products);
    }

    [HttpGet]
    public async Task<IActionResult> CreateProduct()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7201/api/Categories/");
        string jsonData = await responseMessage.Content.ReadAsStringAsync();
        List<ResultCategoryDto> categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

        List<SelectListItem> categoryDatas = (from c in categories.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = c.CategoryName,
                                                  Value = c.CategoryId.ToString()
                                              }).ToList();
        ViewBag.CategoryDatas = categoryDatas;
        return View();
    }

    //[HttpPost]
    //public async Task<IActionResult> CreateProduct(CreateProductDto productDto)
    //{
    //    return View();
    //}

    [HttpGet("ProductDealOfTheDayStatusChangeToFalse")]
    public async Task<IActionResult> ProductDealOfTheDayStatusChangeToFalse(int id)
    {
        bool result = await _apiClient.ProductDealOfTheDayStatusChangeToFalseAsync(id);
        if (result)
            return RedirectToAction(nameof(Index));
        return View();
    }

    [HttpGet("ProductDealOfTheDayStatusChangeToTrue")]
    public async Task<IActionResult> ProductDealOfTheDayStatusChangeToTrue(int id)
    {
        bool result = await _apiClient.ProductDealOfTheDayStatusChangeToTrueAsync(id);
        if(result)
            return RedirectToAction(nameof(Index));
        return View();
    }
}
