using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RealEstate.WebUI.Dtos.CategoryDtos;
using RealEstate.WebUI.Dtos.ProductDtos;

namespace RealEstate.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class ProductsController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ProductsController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IActionResult> Index()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7201/api/Products/ProductListWithCategory");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            List<ResultProductDto> products = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            return View(products);
        }
        return View();
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

    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductDto productDto)
    {
        return View();
    }
}
