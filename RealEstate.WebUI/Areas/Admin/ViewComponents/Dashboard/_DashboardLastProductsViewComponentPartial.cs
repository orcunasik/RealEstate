using Microsoft.AspNetCore.Mvc;
using RealEstate.WebUI.ApiClients.Abstracts;
using RealEstate.WebUI.Dtos.ProductDtos;

namespace RealEstate.WebUI.Areas.Admin.ViewComponents.Dashboard;

public class _DashboardLastProductsViewComponentPartial : ViewComponent
{
    private readonly IProductApiClient _apiClient;

    public _DashboardLastProductsViewComponentPartial(IProductApiClient productApiClient)
    {
        _apiClient = productApiClient;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        List<ResultProductWithCategoryDto> lastProducts = await _apiClient.GetLastProductsAsync();
        return View(lastProducts);
    }
}