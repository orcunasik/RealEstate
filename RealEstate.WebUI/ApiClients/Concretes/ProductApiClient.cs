using RealEstate.WebUI.ApiClients.Abstracts;
using RealEstate.WebUI.Configurations;
using RealEstate.WebUI.Dtos.ProductDtos;
using System.Net.Http.Json;

namespace RealEstate.WebUI.ApiClients.Concretes;

public class ProductApiClient : IProductApiClient
{
    private readonly IHttpClientFactory _httpClient;
    private readonly IDomainService _domainService;
    public ProductApiClient(IHttpClientFactory httpClient, IDomainService domainService)
    {
        _httpClient = httpClient;
        _domainService = domainService;
    }
    public async Task<List<ResultProductDto>> GetAllProductAsync()
    {
        HttpClient client = _httpClient.CreateClient();
        List<ResultProductDto>? response = await client.GetFromJsonAsync<List<ResultProductDto>>(_domainService.Domain() + "api/Products");
        return response;
    }

    public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
    {
        HttpClient client = _httpClient.CreateClient();
        List<ResultProductWithCategoryDto>? response = await client.GetFromJsonAsync<List<ResultProductWithCategoryDto>>(_domainService.Domain() + "api/Products/ProductListWithCategory");
        return response;
    }

    public async Task<bool> ProductDealOfTheDayStatusChangeToFalseAsync(int id)
    {
        HttpClient client = _httpClient.CreateClient();
        HttpResponseMessage response = await client.GetAsync(_domainService.Domain() + $"api/Products/ProductDealOfTheDayStatusFalse/{id}");
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> ProductDealOfTheDayStatusChangeToTrueAsync(int id)
    {
        HttpClient client = _httpClient.CreateClient();
        HttpResponseMessage response = await client.GetAsync(_domainService.Domain() + $"api/Products/ProductDealOfTheDayStatusTrue/{id}");
        return response.IsSuccessStatusCode;
    }
}