using Microsoft.AspNetCore.Mvc;
using RealEstate.WebUI.ApiClients.Abstracts;

namespace RealEstate.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class StatisticsController : Controller
{
    private readonly IStatisticsApiClient _apiClient;

    public StatisticsController(IStatisticsApiClient statisticsApiClient)
    {
        _apiClient = statisticsApiClient;
    }

    public async Task<IActionResult> Index()
    {
        #region ActiveCategoryCount
        int activeCategoryCount = await _apiClient.GetActiveCategoryCountAsync();
        ViewBag.ActiveCategoryCount = activeCategoryCount;
        #endregion

        #region ActiveEmployeeCount
        int activeEmployeeCount = await _apiClient.GetActiveEmployeeCountAsync();
        ViewBag.ActiveEmployeeCount = activeEmployeeCount;
        #endregion

        #region ApartmentCount
        int apartmentCount = await _apiClient.GetApartmentCountAsync();
        ViewBag.ApartmentCount = apartmentCount;
        #endregion

        #region AvgProductPriceByRent
        decimal avgProductPriceByRent = await _apiClient.GetAvgProductPriceByRentAsync();
        ViewBag.AvgProductPriceByRent = avgProductPriceByRent;
        #endregion

        #region AvgProductPriceBySale
        decimal avgProductPriceBySale = await _apiClient.GetAvgProductPriceBySaleAsync();
        ViewBag.AvgProductPriceBySale = avgProductPriceBySale;
        #endregion

        #region AvgRoomCount
        int avgRoomCount = await _apiClient.GetAvgRoomCountAsync();
        ViewBag.AvgRoomCount = avgRoomCount;
        #endregion

        #region CategoryCount
        int categoryCount = await _apiClient.GetCategoryCountAsync();
        ViewBag.CategoryCount = categoryCount;
        #endregion

        #region CategoryNameByMaxProductCount
        string categoryNameByMaxProductCount = await _apiClient.GetCategoryNameByMaxProductCountAsync();
        ViewBag.CategoryNameByMaxProductCount = categoryNameByMaxProductCount;
        #endregion

        #region CityNameByMaxProductCount
        string cityNameByMaxProdcutCount = await _apiClient.GetCityNameByMaxProductCountAsync();
        ViewBag.CityNameByMaxProductCount = cityNameByMaxProdcutCount;
        #endregion

        #region DifferentCityCount
        int differentCount = await _apiClient.GetDifferentCityCountAsync();
        ViewBag.DifferentCityCount = differentCount;
        #endregion

        #region EmployeeNameByMaxProductCount
        string employeeNameByMaxProductCount = await _apiClient.GetEmployeeNameByMaxProductCountAsync();
        ViewBag.EmployeeNameByMaxProductCount = employeeNameByMaxProductCount;
        #endregion

        #region LastProductPrice
        decimal lastProductPrice = await _apiClient.GetLastProdcutPriceAsync();
        ViewBag.LastProductPrice = lastProductPrice;
        #endregion

        #region NewestBuildingYear
        string newestBuildingYear = await _apiClient.GetNewestBuildingYearAsync();
        ViewBag.NewestBuildingYear = newestBuildingYear;
        #endregion

        #region OldestBuildingYear
        string oldestBuildingYear = await _apiClient.GetOldestBuildingYearAsync();
        ViewBag.OldestBuildingYear = oldestBuildingYear;
        #endregion

        #region PassiveCategoryCount
        int passiveCategoryCount = await _apiClient.GetPassiveCategoryCountAsync();
        ViewBag.PassiveCategoryCount = passiveCategoryCount;
        #endregion

        #region ProductCount
        int productCount = await _apiClient.GetProductCountAsync();
        ViewBag.ProductCount = productCount;
        #endregion

        return View();
    }
}
