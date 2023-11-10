using RealEstate.Api.Dtos.CategoryDtos;

namespace RealEstate.Api.Repositories.CategoryRepository;

public interface ICategoryRepository
{
    Task<List<ResultCategoryDto>> GetAllCategoryAsync();
    Task<GetByIdCategoryDto> GetCategoryAsync(int id);
    GetByIdCategoryDto GetCategory(int id);
    Task<CreateCategoryDto> CreateCategoryAsync(CreateCategoryDto categoryDto);
    void DeleteCategory(GetByIdCategoryDto categoryDto);
    void UpdateCategory(UpdateCategoryDto categoryDto);
}
