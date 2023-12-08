using RealEstate.WebUI.Dtos.ProductDtos;

namespace RealEstate.WebUI.ApiClients.Abstracts;

public interface IProductApiClient
{
    Task<List<ResultProductDto>> GetAllProductAsync();
    Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync();
    Task<bool> ProductDealOfTheDayStatusChangeToTrueAsync(int id);
    Task<bool> ProductDealOfTheDayStatusChangeToFalseAsync(int id);
}