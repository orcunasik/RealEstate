using Dapper;
using RealEstate.Api.Dtos.ProductDtos;
using RealEstate.Api.Models.DapperContext;

namespace RealEstate.Api.Repositories.ProductRepository;

public class ProductRepository : IProductRepository
{
    private readonly BaseContext _context;

    public ProductRepository(BaseContext context)
    {
        _context = context;
    }
    public async Task<List<ResultProductDto>> GetAllProductAsync()
    {
        string query = "Select * From Products";
        using (var connection = _context.CreateConnection())
        {
            var products = await connection.QueryAsync<ResultProductDto>(query);
            return products.ToList();
        }
    }

    public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
    {
        string query = "Select ProductId,Title,Price,City,District,CategoryName From Products inner join Categories on Products.CategoryId = Categories.CategoryId";
        using (var connection = _context.CreateConnection())
        {
            var products = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
            return products.ToList();
        }
    }
}
