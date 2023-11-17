using RealEstate.WebUI.ApiClients.Abstracts;
using RealEstate.WebUI.Configurations;
using RealEstate.WebUI.Dtos.PopularLocationDtos;

namespace RealEstate.WebUI.ApiClients.Concretes;

public class PopularLocationApiClient : IPopularLocationApiClient
{
    private readonly IHttpClientFactory _httpClient;
    private readonly IDomainService _domainService;
    public PopularLocationApiClient(IHttpClientFactory httpClient, IDomainService domainService)
    {
        _httpClient = httpClient;
        _domainService = domainService;
    }
    public async Task<CreatePopularLocationDto> AddAsync(CreatePopularLocationDto popularLocationDto)
    {
        HttpClient client = _httpClient.CreateClient();
        HttpResponseMessage response = await client.PostAsJsonAsync(_domainService.Domain() + "api/PopularLocations", popularLocationDto);
        if (response.IsSuccessStatusCode)
            return await response.Content.ReadFromJsonAsync<CreatePopularLocationDto>();
        return null;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        HttpClient client = _httpClient.CreateClient();
        HttpResponseMessage response = await client.DeleteAsync(_domainService.Domain() + $"api/PopularLocations/{id}");
        return response.IsSuccessStatusCode;
    }

    public async Task<List<ResultPopularLocationDto>> GetAllAsync()
    {
        HttpClient client = _httpClient.CreateClient();
        List<ResultPopularLocationDto>? response = await client.GetFromJsonAsync<List<ResultPopularLocationDto>>(_domainService.Domain() + "api/PopularLocations");
        return response;
    }

    public async Task<UpdatePopularLocationDto> GetUpdateAsync(int id)
    {
        HttpClient client = _httpClient.CreateClient();
        UpdatePopularLocationDto? response = await client.GetFromJsonAsync<UpdatePopularLocationDto>(_domainService.Domain() + $"api/PopularLocations/{id}");
        return response;
    }

    public async Task<bool> UpdateAsync(UpdatePopularLocationDto popularLocationDto)
    {
        HttpClient client = _httpClient.CreateClient();
        HttpResponseMessage response = await client.PutAsJsonAsync(_domainService.Domain() + "api/PopularLocations/", popularLocationDto);
        return response.IsSuccessStatusCode;
    }
}
