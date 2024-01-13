using Microsoft.AspNetCore.Mvc;
using RealEstate.WebUI.ApiClients.Abstracts;

namespace RealEstate.WebUI.Areas.Admin.ViewComponents.Dashboard;

public class _DashboardStatisticsViewComponentPartial : ViewComponent
{
    private readonly IStatisticsApiClient _apiClient;

    public _DashboardStatisticsViewComponentPartial(IStatisticsApiClient statisticsApiClient)
    {
        _apiClient = statisticsApiClient;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        #region TotalProduct
        int productCount = await _apiClient.GetProductCountAsync();
        ViewBag.ProductCount = productCount;
        #endregion

        #region CityNameByMaxProductCount
        string cityNameByMaxProdcutCount = await _apiClient.GetCityNameByMaxProductCountAsync();
        ViewBag.CityNameByMaxProductCount = cityNameByMaxProdcutCount;
        #endregion

        #region AvgProductPriceBySale
        decimal avgProductPriceBySale = await _apiClient.GetAvgProductPriceBySaleAsync();
        ViewBag.AvgProductPriceBySale = avgProductPriceBySale;
        #endregion

        #region AvgProductPriceByRent
        decimal avgProductPriceByRent = await _apiClient.GetAvgProductPriceByRentAsync();
        ViewBag.AvgProductPriceByRent = avgProductPriceByRent;
        #endregion

        return View();
    }
}