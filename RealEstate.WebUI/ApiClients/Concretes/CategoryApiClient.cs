using RealEstate.WebUI.ApiClients.Abstracts;
using RealEstate.WebUI.Configurations;
using RealEstate.WebUI.Dtos.CategoryDtos;

namespace RealEstate.WebUI.ApiClients.Concretes;

public class CategoryApiClient : ICategoryApiClient
{
    private readonly IHttpClientFactory _httpClient;
    private readonly IDomainService _domainService;
    public CategoryApiClient(IHttpClientFactory httpClient, IDomainService domainService)
    {
        _httpClient = httpClient;
        _domainService = domainService;
    }

    public async Task<CreateCategoryDto> AddAsync(CreateCategoryDto categoryDto)
    {
        HttpClient client = _httpClient.CreateClient();
        HttpResponseMessage response = await client.PostAsJsonAsync(_domainService.Domain() + "api/Categories",categoryDto);
        if(response.IsSuccessStatusCode)
            return await response.Content.ReadFromJsonAsync<CreateCategoryDto>();
        return null;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        HttpClient client = _httpClient.CreateClient();
        HttpResponseMessage response = await client.DeleteAsync(_domainService.Domain() + $"api/Categories/{id}");
        return response.IsSuccessStatusCode;
    }

    public async Task<List<ResultCategoryDto>> GetAllAsync()
    {
        HttpClient client = _httpClient.CreateClient();
        List<ResultCategoryDto>? response = await client.GetFromJsonAsync<List<ResultCategoryDto>>(_domainService.Domain() + "api/Categories");
        return response;
    }

    public async Task<UpdateCategoryDto> GetUpdateAsync(int id)
    {
        HttpClient client = _httpClient.CreateClient();
        UpdateCategoryDto? response = await client.GetFromJsonAsync<UpdateCategoryDto>(_domainService.Domain() + $"api/Categories/{id}");
        return response;        
    }

    public async Task<bool> UpdateAsync(UpdateCategoryDto categoryDto)
    {
        HttpClient client = _httpClient.CreateClient();
        HttpResponseMessage response = await client.PutAsJsonAsync(_domainService.Domain() + $"api/Categories/{categoryDto.CategoryId}", categoryDto);
        return response.IsSuccessStatusCode;
    }
}