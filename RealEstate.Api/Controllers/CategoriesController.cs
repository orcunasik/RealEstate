using Microsoft.AspNetCore.Mvc;
using RealEstate.Api.Dtos.CategoryDtos;
using RealEstate.Api.Repositories.CategoryRepository;

namespace RealEstate.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoriesController(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    [HttpGet]
    public async Task<IActionResult> CategoryList()
    {
        List<ResultCategoryDto> categories = await _categoryRepository.GetAllCategoryAsync();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> CategoryById(int id)
    {
        GetByIdCategoryDto category = await _categoryRepository.GetCategoryAsync(id);
        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryDto categoryDto)
    {
        CreateCategoryDto category = await _categoryRepository.CreateCategoryAsync(categoryDto);
        return Ok(category);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCategory(int id)
    {
        GetByIdCategoryDto categoryDto = _categoryRepository.GetCategory(id);
        _categoryRepository.DeleteCategory(categoryDto);
        return Ok("Kategori Başarılı Bir Şekilde Silindi!");

    }

    [HttpPut]
    public IActionResult UpdateCategory(UpdateCategoryDto categoryDto)
    {
        _categoryRepository.UpdateCategory(categoryDto);
        return Ok("Kategori Başarılı Bir Şekilde Güncellendi!");
    }
}
