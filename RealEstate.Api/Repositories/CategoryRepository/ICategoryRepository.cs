using RealEstate.Api.Dtos.CategoryDtos;

namespace RealEstate.Api.Repositories.CategoryRepository;

public interface ICategoryRepository
{
    Task<List<ResultCategoryDto>> GetAllCategoryAsync();
    Task<GetByIdCategoryDto> GetCategoryAsync(int id);
    void CreateCategory(CreateCategoryDto categoryDto);
    void DeleteCategory(int id);
    void UpdateCategory(UpdateCategoryDto categoryDto);
}
