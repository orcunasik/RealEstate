using Microsoft.AspNetCore.Mvc;
using RealEstate.WebUI.ApiClients.Concretes;
using RealEstate.WebUI.Dtos.CategoryDtos;

namespace RealEstate.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class CategoriesController : Controller
{
    private readonly CategoryApiClient _apiClient;

    public CategoriesController(CategoryApiClient categoryApiClient)
    {
        _apiClient = categoryApiClient;
    }
    public async Task<IActionResult> Index()
    {
        List<ResultCategoryDto> categories = await _apiClient.GetAllAsync();
        if (categories is not null)
            return View(categories);
        return View();
    }

    [HttpGet]
    public IActionResult CreateCategory()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryDto categoryDto)
    {
        await _apiClient.AddAsync(categoryDto);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> DeleteCategory(int id)
    {
        bool isSuccess = await _apiClient.DeleteAsync(id);
        if (isSuccess)
            return RedirectToAction(nameof(Index));
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> UpdateCategory(int id)
    {
        UpdateCategoryDto category = await _apiClient.GetUpdateAsync(id);
        if (category is not null)
            return View(category);
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryDto categoryDto)
    {
        bool isSuccess = await _apiClient.UpdateAsync(categoryDto);
        if (isSuccess)
            return RedirectToAction(nameof(Index));
        return View();
    }
}