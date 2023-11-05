using RealEstate.WebUI.Dtos.CategoryDtos;

namespace RealEstate.WebUI.ApiClients.Abstracts;

public interface ICategoryApiClient
{
    Task<List<ResultCategoryDto>> GetAllAsync();
    Task<UpdateCategoryDto> GetUpdateAsync(int id);
    Task<CreateCategoryDto> AddAsync(CreateCategoryDto categoryDto);
    Task<bool> UpdateAsync(UpdateCategoryDto categoryDto);
    Task<bool> DeleteAsync(int id);
}
