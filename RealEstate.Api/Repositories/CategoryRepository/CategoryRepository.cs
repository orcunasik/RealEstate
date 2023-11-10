using Dapper;
using RealEstate.Api.Dtos.CategoryDtos;
using RealEstate.Api.Models.DapperContext;
using System.Data;

namespace RealEstate.Api.Repositories.CategoryRepository;

public class CategoryRepository : ICategoryRepository
{
    private readonly BaseContext _context;

    public CategoryRepository(BaseContext context)
    {
        _context = context;
    }

    public async Task<CreateCategoryDto> CreateCategoryAsync(CreateCategoryDto categoryDto)
    {
        string insertQuery = "Insert into Categories (CategoryName,Status) values (@categoryName,@status);SELECT SCOPE_IDENTITY()";
        DynamicParameters parameters = new();
        parameters.Add("@categoryName", categoryDto.CategoryName);
        parameters.Add("@status", true);
        using (IDbConnection connection = _context.CreateConnection())
        {
            int categoryId = await connection.QuerySingleAsync<int>(insertQuery, parameters);
            string selectQuery = "Select * From Categories Where CategoryId = @categoryId";
            CreateCategoryDto category = await connection.QuerySingleOrDefaultAsync<CreateCategoryDto>(selectQuery, new { categoryId });
            return category;
        }
    }

    public async void DeleteCategory(GetByIdCategoryDto categoryDto)
    {
        string deleteQuery = "DELETE FROM ProductDetails WHERE ProductId IN (SELECT ProductId FROM Products WHERE CategoryId = @categoryId); DELETE FROM Products WHERE CategoryId = @categoryId;DELETE FROM Categories Where CategoryId = @categoryId";
        DynamicParameters parameter = new();
        parameter.Add("@categoryId", categoryDto.CategoryId);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(deleteQuery, parameter);
        }
    }

    public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
    {
        string listQuery = "Select * From Categories";
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<ResultCategoryDto> categories = await connection.QueryAsync<ResultCategoryDto>(listQuery);
            return categories.ToList();
        }
    }

    public GetByIdCategoryDto GetCategory(int id)
    {
        string getByIdQuery = "Select * From Categories Where CategoryId = @categoryId";
        DynamicParameters parameter = new();
        parameter.Add("@categoryId", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            dynamic category = connection.QueryFirstOrDefault<GetByIdCategoryDto>(getByIdQuery, parameter);
            return category;
        }
    }

    public async Task<GetByIdCategoryDto> GetCategoryAsync(int id)
    {
        string getByIdQuery = "Select * From Categories Where CategoryId = @categoryId";
        DynamicParameters parameter = new();
        parameter.Add("@categoryId", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            dynamic category = await connection.QueryFirstOrDefaultAsync<GetByIdCategoryDto>(getByIdQuery, parameter);
            return category;
        }
    }

    public async void UpdateCategory(UpdateCategoryDto categoryDto)
    {
        string updateQuery = "Update Categories Set CategoryName = @categoryName, Status = @status Where CategoryId = @categoryId";
        DynamicParameters parameters = new();
        parameters.Add("@categoryId", categoryDto.CategoryId);
        parameters.Add("@categoryName", categoryDto.CategoryName);
        parameters.Add("@status", categoryDto.Status);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(updateQuery, parameters);
        }
    }
}
