using RealEstate.WebUI.ApiClients.Abstracts;
using RealEstate.WebUI.Configurations;
using RealEstate.WebUI.Dtos.BottomGridDtos;

namespace RealEstate.WebUI.ApiClients.Concretes;

public class BottomGridApiClient : IBottomGridApiClient
{
    private readonly IHttpClientFactory _httpClient;
    private readonly IDomainService _domainService;
    public BottomGridApiClient(IHttpClientFactory httpClient, IDomainService domainService)
    {
        _httpClient = httpClient;
        _domainService = domainService;
    }
    public async Task<CreateBottomGridDto> AddAsync(CreateBottomGridDto bottomGridDto)
    {
        HttpClient client = _httpClient.CreateClient();
        HttpResponseMessage response = await client.PostAsJsonAsync(_domainService.Domain() + "api/BottomGrids", bottomGridDto);
        if (response.IsSuccessStatusCode)
            return await response.Content.ReadFromJsonAsync<CreateBottomGridDto>();
        return null;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        HttpClient client = _httpClient.CreateClient();
        HttpResponseMessage response = await client.DeleteAsync(_domainService.Domain() + $"api/BottomGrids/{id}");
        return response.IsSuccessStatusCode;
    }

    public async Task<List<ResultBottomGridDto>> GetAllAsync()
    {
        HttpClient client = _httpClient.CreateClient();
        List<ResultBottomGridDto>? response = await client.GetFromJsonAsync<List<ResultBottomGridDto>>(_domainService.Domain() + "api/BottomGrids");
        return response;
    }

    public async Task<UpdateBottomGridDto> GetUpdateAsync(int id)
    {
        HttpClient client = _httpClient.CreateClient();
        UpdateBottomGridDto? response = await client.GetFromJsonAsync<UpdateBottomGridDto>(_domainService.Domain() + $"api/BottomGrids/{id}");
        return response;
    }

    public async Task<bool> UpdateAsync(UpdateBottomGridDto bottomGridDto)
    {
        HttpClient client = _httpClient.CreateClient();
        HttpResponseMessage response = await client.PutAsJsonAsync(_domainService.Domain() + "api/BottomGrids/", bottomGridDto);
        return response.IsSuccessStatusCode;
    }
}
