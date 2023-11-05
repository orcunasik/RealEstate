using RealEstate.WebUI.ApiClients.Abstracts;
using RealEstate.WebUI.Configurations;
using RealEstate.WebUI.Dtos.ServiceDtos;

namespace RealEstate.WebUI.ApiClients.Concretes;

public class ServiceApiClient : IServiceApiClient
{
    private readonly IHttpClientFactory _httpClient;
    private readonly IDomainService _domainService;
    public ServiceApiClient(IHttpClientFactory httpClient, IDomainService domainService)
    {
        _httpClient = httpClient;
        _domainService = domainService;
    }
    public async Task<CreateServiceDto> AddAsync(CreateServiceDto serviceDto)
    {
        HttpClient client = _httpClient.CreateClient();
        HttpResponseMessage response = await client.PostAsJsonAsync(_domainService.Domain() + "api/Services/",serviceDto);
        if (response.IsSuccessStatusCode)
            return await response.Content.ReadFromJsonAsync<CreateServiceDto>();
        return null;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        HttpClient client = _httpClient.CreateClient();
        HttpResponseMessage response = await client.DeleteAsync(_domainService.Domain() + $"api/Services/{id}");
        return response.IsSuccessStatusCode;
    }

    public async Task<List<ResultServiceDto>> GetAllAsync()
    {
        HttpClient client = _httpClient.CreateClient();
        List<ResultServiceDto>? response = await client.GetFromJsonAsync<List<ResultServiceDto>>(_domainService.Domain() + "api/Services");
        return response;
    }

    public async Task<UpdateServiceDto> GetUpdateAsync(int id)
    {
        HttpClient client = _httpClient.CreateClient();
        UpdateServiceDto? response = await client.GetFromJsonAsync<UpdateServiceDto>(_domainService.Domain() + $"api/Services/{id}");
        return response;
    }

    public async Task<bool> UpdateAsync(UpdateServiceDto serviceDto)
    {
        HttpClient client = _httpClient.CreateClient();
        HttpResponseMessage response = await client.PutAsJsonAsync(_domainService.Domain() + "api/Services/", serviceDto);
        return response.IsSuccessStatusCode;
    }
}