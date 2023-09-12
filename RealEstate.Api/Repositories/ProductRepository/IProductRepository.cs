using RealEstate.Api.Dtos.ProductDtos;

namespace RealEstate.Api.Repositories.ProductRepository;

public interface IProductRepository
{
    Task<List<ResultProductDto>> GetAllProductAsync();
    Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync();
}
