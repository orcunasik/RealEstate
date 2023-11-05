using RealEstate.WebUI.ApiClients.Abstracts;
using RealEstate.WebUI.Configurations;
using RealEstate.WebUI.Dtos.WhoWeAreDetailDtos;

namespace RealEstate.WebUI.ApiClients.Concretes;

public class WhoWeAreApiClient : IWhoWeAreApiClient
{
    private readonly IHttpClientFactory _httpClient;
    private readonly IDomainService _domainService;
    public WhoWeAreApiClient(IHttpClientFactory httpClient, IDomainService domainService)
    {
        _httpClient = httpClient;
        _domainService = domainService;
    }
    public async Task<CreateWhoWeAreDetailDto> AddAsync(CreateWhoWeAreDetailDto weAreDetailDto)
    {
        HttpClient client = _httpClient.CreateClient();
        HttpResponseMessage response = await client.PostAsJsonAsync(_domainService.Domain() + "api/WhoWeAreDetails", weAreDetailDto);
        if (response.IsSuccessStatusCode)
            return await response.Content.ReadFromJsonAsync<CreateWhoWeAreDetailDto>();
        return null;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        HttpClient client = _httpClient.CreateClient();
        HttpResponseMessage response = await client.DeleteAsync(_domainService.Domain() + $"api/WhoWeAreDetails/{id}");

        return response.IsSuccessStatusCode;
    }

    public async Task<List<ResultWhoWeAreDetailDto>> GetAllAsync()
    {
        HttpClient client = _httpClient.CreateClient();
        List<ResultWhoWeAreDetailDto>? response = await client.GetFromJsonAsync<List<ResultWhoWeAreDetailDto>>(_domainService.Domain() + "api/WhoWeAreDetails");
        return response;
    }

    public async Task<UpdateWhoWeAreDetailDto> GetUpdateAsync(int id)
    {
        HttpClient client = _httpClient.CreateClient();
        UpdateWhoWeAreDetailDto? response = await client.GetFromJsonAsync<UpdateWhoWeAreDetailDto>(_domainService.Domain() + $"api/WhoWeAreDetails/{id}");
        return response;
    }

    public async Task<bool> UpdateAsync(UpdateWhoWeAreDetailDto weAreDetailDto)
    {
        HttpClient client = _httpClient.CreateClient();
        HttpResponseMessage response = await client.PutAsJsonAsync(_domainService.Domain() + "api/WhoWeAreDetails/", weAreDetailDto);
        return response.IsSuccessStatusCode;
    }
}