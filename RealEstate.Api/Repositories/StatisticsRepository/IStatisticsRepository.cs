namespace RealEstate.Api.Repositories.StatisticsRepository;

public interface IStatisticsRepository
{
    int CategoryCount();
    int ActiveCategoryCount();
    int PassiveCategoryCount();
    int ProductCount();
    int ApartmentCount();
    string EmployeeNameByMaxProductCount();
    string CategoryNameByMaxProductCount();
    decimal AvgProductPriceByRent();
    decimal AvgProductPriceBySale();
    string CityNameByMaxProductCount();
    int DifferentCityCount();
    decimal LastProductPrice();
    string NewestBuildingYear();
    string OldestBuildingYear();
    int AvgRoomCount();
    int ActiveEmployeeCount();
}
