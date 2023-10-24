using Microsoft.AspNetCore.Mvc;
using RealEstate.Api.Repositories.StatisticsRepository;

namespace RealEstate.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatisticsController : ControllerBase
{
    private readonly IStatisticsRepository _statisticsRepository;

    public StatisticsController(IStatisticsRepository statisticsRepository)
    {
        _statisticsRepository = statisticsRepository;
    }

    [HttpGet("ActiveCategoryCount")]
    public IActionResult ActiveCategoryCount()
    {
        int activeCategoryCount = _statisticsRepository.ActiveCategoryCount();
        return Ok(activeCategoryCount);
    }
    
    [HttpGet("ActiveEmployeeCount")]
    public IActionResult ActiveEmployeeCount()
    {
        int activeEmployeeCount = _statisticsRepository.ActiveEmployeeCount();
        return Ok(activeEmployeeCount);
    }
    
    [HttpGet("ApartmentCount")]
    public IActionResult ApartmentCount()
    {
        int apartmentCount = _statisticsRepository.ApartmentCount();
        return Ok(apartmentCount);
    }
    
    [HttpGet("AvgProductPriceByRent")]
    public IActionResult AvgProductPriceByRent()
    {
        decimal avgProductPriceByRent = _statisticsRepository.AvgProductPriceByRent();
        return Ok(avgProductPriceByRent);
    }
    
    [HttpGet("AvgProductPriceBySale")]
    public IActionResult AvgProductPriceBySale()
    {
        decimal avgProductPriceBySale = _statisticsRepository.AvgProductPriceBySale();
        return Ok(avgProductPriceBySale);
    }

    [HttpGet("AvgRoomCount")]
    public IActionResult AvgRoomCount()
    {
        int avgRoomCount = _statisticsRepository.AvgRoomCount();
        return Ok(avgRoomCount);
    }

    [HttpGet("CategoryCount")]
    public IActionResult CategoryCount()
    {
        int categoryCount = _statisticsRepository.CategoryCount();
        return Ok(categoryCount);
    }

    [HttpGet("CategoryNameByMaxProductCount")]
    public IActionResult CategoryNameByMaxProductCount()
    {
        string categoryNameByMaxProductCount = _statisticsRepository.CategoryNameByMaxProductCount();
        return Ok(categoryNameByMaxProductCount);
    }
    
    [HttpGet("CityNameByMaxProductCount")]
    public IActionResult CityNameByMaxProductCount()
    {
        string cityNameByMaxProductCount = _statisticsRepository.CityNameByMaxProductCount();
        return Ok(cityNameByMaxProductCount);
    }

    [HttpGet("DifferentCityCount")]
    public IActionResult DifferentCityCount()
    {
        int differentCityCount = _statisticsRepository.DifferentCityCount();
        return Ok(differentCityCount);
    }

    [HttpGet("EmployeeNameByMaxProductCount")]
    public IActionResult EmployeeNameByMaxProductCount()
    {
        string employeeNameByMaxProductCount = _statisticsRepository.EmployeeNameByMaxProductCount();
        return Ok(employeeNameByMaxProductCount);
    }

    [HttpGet("LastProductPrice")]
    public IActionResult LastProductPrice()
    {
        decimal lastProductPrice = _statisticsRepository.LastProductPrice();
        return Ok(lastProductPrice);
    }

    [HttpGet("NewestBuildingYear")]
    public IActionResult NewestBuildingYear()
    {
        string newestBuildingYear = _statisticsRepository.NewestBuildingYear();
        return Ok(newestBuildingYear);
    }

    [HttpGet("OldestBuildingYear")]
    public IActionResult OldestBuildingYear()
    {
        string oldestBuildingYear = _statisticsRepository.OldestBuildingYear();
        return Ok(oldestBuildingYear);
    }

    [HttpGet("PassiveCategoryCount")]
    public IActionResult PassiveCategoryCount()
    {
        int passiveCategoryCount = _statisticsRepository.PassiveCategoryCount();
        return Ok(passiveCategoryCount);
    }

    [HttpGet("ProductCount")]
    public IActionResult ProductCount()
    {
        int productCount = _statisticsRepository.ProductCount();
        return Ok(productCount);
    }
}
