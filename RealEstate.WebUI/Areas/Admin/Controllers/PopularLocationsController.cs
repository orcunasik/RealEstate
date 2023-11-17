using Microsoft.AspNetCore.Mvc;
using RealEstate.WebUI.ApiClients.Abstracts;
using RealEstate.WebUI.Dtos.PopularLocationDtos;

namespace RealEstate.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class PopularLocationsController : Controller
{
    private readonly IPopularLocationApiClient _apiClient;

    public PopularLocationsController(IPopularLocationApiClient popularLocationApiClient)
    {
        _apiClient = popularLocationApiClient;
    }

    public async Task<IActionResult> Index()
    {
        List<ResultPopularLocationDto> popularLocations = await _apiClient.GetAllAsync();
        if (popularLocations is not null)
            return View(popularLocations);
        return View();
    }

    [HttpGet]
    public IActionResult CreatePopularLocation()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreatePopularLocation(CreatePopularLocationDto popularLocationDto)
    {
        await _apiClient.AddAsync(popularLocationDto);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> DeletePopularLocation(int id)
    {
        bool isSuccess = await _apiClient.DeleteAsync(id);
        if (isSuccess)
            return RedirectToAction(nameof(Index));
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> UpdatePopularLocation(int id)
    {
        UpdatePopularLocationDto popularLocation = await _apiClient.GetUpdateAsync(id);
        if (popularLocation is not null)
            return View(popularLocation);
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdatePopularLocation(UpdatePopularLocationDto popularLocationDto)
    {
        bool isSuccess = await _apiClient.UpdateAsync(popularLocationDto);
        if (isSuccess)
            return RedirectToAction(nameof(Index));
        return View();
    }
}
