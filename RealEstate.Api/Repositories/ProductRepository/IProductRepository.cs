using RealEstate.Api.Dtos.ProductDtos;

namespace RealEstate.Api.Repositories.ProductRepository;

public interface IProductRepository
{
    Task<List<ResultProductDto>> GetAllProductAsync();
    Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync();
    Task ProductDealOfTheDayStatusChangeToTrueAsync(int id);
    Task ProductDealOfTheDayStatusChangeToFalseAsync(int id);
    Task<List<ResultProductWithCategoryDto>> GetLastProductsAsync();
}