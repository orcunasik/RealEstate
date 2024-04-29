namespace RealEstate.WebUI.ApiClients.Abstracts;

public interface IStatisticsApiClient
{
    Task<int> GetCategoryCountAsync();
    Task<int> GetActiveCategoryCountAsync();
    Task<int> GetPassiveCategoryCountAsync();
    Task<int> GetProductCountAsync();
    Task<int> GetApartmentCountAsync();
    Task<int> GetAvgRoomCountAsync();
    Task<int> GetActiveEmployeeCountAsync();
    Task<int> GetDifferentCityCountAsync();

    Task<decimal> GetLastProdcutPriceAsync();
    Task<decimal> GetAvgProductPriceByRentAsync();
    Task<decimal> GetAvgProductPriceBySaleAsync();

    Task<string> GetEmployeeNameByMaxProductCountAsync();
    Task<string> GetCategoryNameByMaxProductCountAsync();
    Task<string> GetCityNameByMaxProductCountAsync();
    Task<string> GetNewestBuildingYearAsync();
    Task<string> GetOldestBuildingYearAsync();
}
