using Dapper;
using RealEstate.Api.Dtos.ProductDtos;
using RealEstate.Api.Models.DapperContext;
using System.Data;

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
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<ResultProductDto> products = await connection.QueryAsync<ResultProductDto>(query);
            return products.ToList();
        }
    }

    public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
    {
        string query = "Select ProductId,Title,Price,City,District,CategoryName,Type,CoverImage,Address,IsDealOfTheDay From Products inner join Categories on Products.CategoryId = Categories.CategoryId";
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<ResultProductWithCategoryDto> products = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
            return products.ToList();
        }
    }

    public async Task ProductDealOfTheDayStatusChangeToFalse(int id)
    {
        string updateQuery = "Update Products Set IsDealOfTheDay = @isDealOfTheDay where ProductId = @productId";
        DynamicParameters parameters = new();
        parameters.Add("@productId", id);
        parameters.Add("@isDealOfTheDay", false);

        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(updateQuery, parameters);
        }
    }

    public async Task ProductDealOfTheDayStatusChangeToTrue(int id)
    {
        string updateQuery = "Update Products Set IsDealOfTheDay = @isDealOfTheDay where ProductId = @productId";
        DynamicParameters parameters = new();
        parameters.Add("@productId", id);
        parameters.Add("@isDealOfTheDay", true);

        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(updateQuery, parameters);
        }
    }
}
