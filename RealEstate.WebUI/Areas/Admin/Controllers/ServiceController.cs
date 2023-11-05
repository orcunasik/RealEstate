using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate.WebUI.ApiClients.Abstracts;
using RealEstate.WebUI.Dtos.CategoryDtos;
using RealEstate.WebUI.Dtos.ServiceDtos;
using System.Text;

namespace RealEstate.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class ServiceController : Controller
{
    private readonly IServiceApiClient _apiClient;

    public ServiceController(IServiceApiClient serviceApiClient)
    {
        _apiClient = serviceApiClient;
    }

    public async Task<IActionResult> Index()
    {
        List<ResultServiceDto> services = await _apiClient.GetAllAsync();
        if (services is not null)
            return View(services);
        return View();
    }

    [HttpGet]
    public IActionResult CreateService()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateService(CreateServiceDto serviceDto)
    {
        await _apiClient.AddAsync(serviceDto);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> DeleteService(int id)
    {
        bool isSuccess = await _apiClient.DeleteAsync(id);
        if (isSuccess)
            return RedirectToAction(nameof(Index));
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> UpdateService(int id)
    {
        UpdateServiceDto service = await _apiClient.GetUpdateAsync(id);
        if (service is not null)
            return View(service);
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateService(UpdateServiceDto serviceDto)
    {
        bool isSuccess = await _apiClient.UpdateAsync(serviceDto);
        if (isSuccess)
            return RedirectToAction(nameof(Index));
        return View();
    }
}
