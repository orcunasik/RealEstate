using Microsoft.AspNetCore.Mvc;
using RealEstate.WebUI.ApiClients.Abstracts;
using RealEstate.WebUI.Dtos.BottomGridDtos;

namespace RealEstate.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class BottomGridsController : Controller
{
    private readonly IBottomGridApiClient _apiClient;

    public BottomGridsController(IBottomGridApiClient bottomGridApiClient)
    {
        _apiClient = bottomGridApiClient;
    }

    public async Task<IActionResult> Index()
    {
        List<ResultBottomGridDto> bottomGrids = await _apiClient.GetAllAsync();
        if (bottomGrids is not null)
            return View(bottomGrids);
        return View();
    }

    [HttpGet]
    public IActionResult CreateBottomGrid()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateBottomGrid(CreateBottomGridDto bottomGridDto)
    {
        await _apiClient.AddAsync(bottomGridDto);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> DeleteBottomGrid(int id)
    {
        bool isSuccess = await _apiClient.DeleteAsync(id);
        if (isSuccess)
            return RedirectToAction(nameof(Index));
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> UpdateBottomGrid(int id)
    {
        UpdateBottomGridDto bottomGrid = await _apiClient.GetUpdateAsync(id);
        if (bottomGrid is not null)
            return View(bottomGrid);
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateBottomGrid(UpdateBottomGridDto bottomGridDto)
    {
        bool isSuccess = await _apiClient.UpdateAsync(bottomGridDto);
        if (isSuccess)
            return RedirectToAction(nameof(Index));
        return View();
    }
}
