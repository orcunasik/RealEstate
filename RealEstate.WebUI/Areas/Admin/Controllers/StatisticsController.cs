using Microsoft.AspNetCore.Mvc;

namespace RealEstate.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class StatisticsController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public StatisticsController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        HttpClient client = _httpClientFactory.CreateClient();

        #region ActiveCategoryCount
        HttpResponseMessage responseMessage1 = await client.GetAsync("https://localhost:7201/api/Statistics/ActiveCategoryCount");
        string jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
        ViewBag.ActiveCategoryCount = jsonData1;
        #endregion

        #region ActiveEmployeeCount
        HttpResponseMessage responseMessage2 = await client.GetAsync("https://localhost:7201/api/Statistics/ActiveEmployeeCount");
        string jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
        ViewBag.ActiveEmployeeCount = jsonData2;
        #endregion

        #region ApartmentCount
        HttpResponseMessage responseMessage3 = await client.GetAsync("https://localhost:7201/api/Statistics/ApartmentCount");
        string jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
        ViewBag.ApartmentCount = jsonData3;
        #endregion

        #region AvgProductPriceByRent
        HttpResponseMessage responseMessage4 = await client.GetAsync("https://localhost:7201/api/Statistics/AvgProductPriceByRent");
        string jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
        ViewBag.AvgProductPriceByRent = jsonData4;
        #endregion

        #region AvgProductPriceBySale
        HttpResponseMessage responseMessage5 = await client.GetAsync("https://localhost:7201/api/Statistics/AvgProductPriceBySale");
        string jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
        ViewBag.AvgProductPriceBySale = jsonData5;
        #endregion

        #region AvgRoomCount
        HttpResponseMessage responseMessage6 = await client.GetAsync("https://localhost:7201/api/Statistics/AvgRoomCount");
        string jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
        ViewBag.AvgRoomCount = jsonData6;
        #endregion

        #region CategoryCount
        HttpResponseMessage responseMessage7 = await client.GetAsync("https://localhost:7201/api/Statistics/CategoryCount");
        string jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
        ViewBag.CategoryCount = jsonData7;
        #endregion

        #region CategoryNameByMaxProductCount
        HttpResponseMessage responseMessage8 = await client.GetAsync("https://localhost:7201/api/Statistics/CategoryNameByMaxProductCount");
        string jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
        ViewBag.CategoryNameByMaxProductCount = jsonData8;
        #endregion

        #region CityNameByMaxProductCount
        HttpResponseMessage responseMessage9 = await client.GetAsync("https://localhost:7201/api/Statistics/CityNameByMaxProductCount");
        string jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
        ViewBag.CityNameByMaxProductCount = jsonData9;
        #endregion

        #region DifferentCityCount
        HttpResponseMessage responseMessage10 = await client.GetAsync("https://localhost:7201/api/Statistics/DifferentCityCount");
        string jsonData10 = await responseMessage10.Content.ReadAsStringAsync();
        ViewBag.DifferentCityCount = jsonData10;
        #endregion

        #region EmployeeNameByMaxProductCount
        HttpResponseMessage responseMessage11 = await client.GetAsync("https://localhost:7201/api/Statistics/EmployeeNameByMaxProductCount");
        string jsonData11 = await responseMessage11.Content.ReadAsStringAsync();
        ViewBag.EmployeeNameByMaxProductCount = jsonData11;
        #endregion

        #region LastProductPrice
        HttpResponseMessage responseMessage12 = await client.GetAsync("https://localhost:7201/api/Statistics/LastProductPrice");
        string jsonData12 = await responseMessage12.Content.ReadAsStringAsync();
        ViewBag.LastProductPrice = jsonData12;
        #endregion

        #region NewestBuildingYear
        HttpResponseMessage responseMessage13 = await client.GetAsync("https://localhost:7201/api/Statistics/NewestBuildingYear");
        string jsonData13 = await responseMessage13.Content.ReadAsStringAsync();
        ViewBag.NewestBuildingYear = jsonData13;
        #endregion

        #region OldestBuildingYear
        HttpResponseMessage responseMessage14 = await client.GetAsync("https://localhost:7201/api/Statistics/OldestBuildingYear");
        string jsonData14 = await responseMessage14.Content.ReadAsStringAsync();
        ViewBag.OldestBuildingYear = jsonData14;
        #endregion

        #region PassiveCategoryCount
        HttpResponseMessage responseMessage15 = await client.GetAsync("https://localhost:7201/api/Statistics/PassiveCategoryCount");
        string jsonData15 = await responseMessage15.Content.ReadAsStringAsync();
        ViewBag.PassiveCategoryCount = jsonData15;
        #endregion

        #region ProductCount
        HttpResponseMessage responseMessage16 = await client.GetAsync("https://localhost:7201/api/Statistics/ProductCount");
        string jsonData16 = await responseMessage16.Content.ReadAsStringAsync();
        ViewBag.ProductCount = jsonData16;
        #endregion

        return View();
    }
}
