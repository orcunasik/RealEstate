using Microsoft.AspNetCore.Mvc;
using RealEstate.WebUI.ApiClients.Abstracts;
using RealEstate.WebUI.Dtos.WhoWeAreDetailDtos;

namespace RealEstate.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class WhoWeAreController : Controller
{
    private readonly IWhoWeAreApiClient _apiClient;

    public WhoWeAreController(IWhoWeAreApiClient whoWeAreApiClient)
    {
        _apiClient = whoWeAreApiClient;
    }

    public async Task<IActionResult> Index()
    {
        List<ResultWhoWeAreDetailDto> result = await _apiClient.GetAllAsync();
        if (result is not null)
            return View(result);
        return View();
    }

    [HttpGet]
    public IActionResult CreateWhoWeAreDetail()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateWhoWeAreDetail(CreateWhoWeAreDetailDto whoWeAreDetailDto)
    {
        await _apiClient.AddAsync(whoWeAreDetailDto);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> DeleteWhoWeAreDetail(int id)
    {
        bool isSuccess = await _apiClient.DeleteAsync(id);
        if (isSuccess)
            return RedirectToAction(nameof(Index));
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> UpdateWhoWeAreDetail(int id)
    {
        UpdateWhoWeAreDetailDto result = await _apiClient.GetUpdateAsync(id);
        if (result is not null)
            return View(result);
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto whoWeAreDetailDto)
    {
        bool isSuccess = await _apiClient.UpdateAsync(whoWeAreDetailDto);
        if (isSuccess)
            return RedirectToAction(nameof(Index));
        return View();
    }
}