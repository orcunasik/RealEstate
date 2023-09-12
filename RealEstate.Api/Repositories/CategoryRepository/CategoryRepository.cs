using Dapper;
using RealEstate.Api.Dtos.CategoryDtos;
using RealEstate.Api.Models.DapperContext;

namespace RealEstate.Api.Repositories.CategoryRepository;

public class CategoryRepository : ICategoryRepository
{
    private readonly BaseContext _context;

    public CategoryRepository(BaseContext context)
    {
        _context = context;
    }

    public async void CreateCategory(CreateCategoryDto categoryDto)
    {
        string query = "Insert into Categories (CategoryName,Status) values (@categoryName,@status)";
        var parameters = new DynamicParameters();
        parameters.Add("@categoryName", categoryDto.CategoryName);
        parameters.Add("@status", true);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async void DeleteCategory(int id)
    {
        string query = "Delete From Categories Where CategoryId = @categoryId";
        var parameters = new DynamicParameters();
        parameters.Add("@categoryId", id);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
    {
        string query = "Select * From Categories";
        using (var connection = _context.CreateConnection())
        {
            var categories = await connection.QueryAsync<ResultCategoryDto>(query);
            return categories.ToList();
        }
    }

    public async Task<GetByIdCategoryDto> GetCategoryAsync(int id)
    {
        string query = "Select * From Categories Where CategoryId = @categoryId";
        var parameters = new DynamicParameters();
        parameters.Add("@categoryId", id);
        using (var connection = _context.CreateConnection())
        {
            dynamic category = await connection.QueryFirstOrDefaultAsync<GetByIdCategoryDto>(query, parameters);
            return category;
        }
    }

    public async void UpdateCategory(UpdateCategoryDto categoryDto)
    {
        string query = "Update Categories Set CategoryName = @categoryName, Status = @status Where CategoryId = @categoryId";
        var parameters = new DynamicParameters();
        parameters.Add("@categoryId", categoryDto.CategoryId);
        parameters.Add("@categoryName", categoryDto.CategoryName);
        parameters.Add("@status", categoryDto.Status);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
