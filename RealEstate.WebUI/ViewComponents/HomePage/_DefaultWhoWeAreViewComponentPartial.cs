using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate.WebUI.Dtos.ProductDtos;
using RealEstate.WebUI.Dtos.WhoWeAreDetailDtos;

namespace RealEstate.WebUI.ViewComponents.HomePage;

public class _DefaultWhoWeAreViewComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    public _DefaultWhoWeAreViewComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7201/api/WhoWeAreDetails/");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<ResultWhoWeAreDetailDto>>(jsonData);
            ViewBag.Title = value[0].Title;
            ViewBag.Subtitle = value[0].Subtitle;
            ViewBag.Description1 = value[0].Description1;
            ViewBag.Description2 = value[0].Description2;

            return View();
        }
        return View();
    }
}
