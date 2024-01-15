using RealEstate.WebUI.ApiClients.Abstracts;
using RealEstate.WebUI.Configurations;
using RealEstate.WebUI.Dtos.ToDoListDtos;

namespace RealEstate.WebUI.ApiClients.Concretes;

public class ToDoListApiClient : IToDoListApiClient
{
    private readonly IHttpClientFactory _httpClient;
    private readonly IDomainService _domainService;
    public ToDoListApiClient(IHttpClientFactory httpClient, IDomainService domainService)
    {
        _httpClient = httpClient;
        _domainService = domainService;
    }
    public async Task<List<ResultToDoListDto>> GetAllToDoListAsync()
    {
        HttpClient client = _httpClient.CreateClient();
        List<ResultToDoListDto>? response = await client.GetFromJsonAsync<List<ResultToDoListDto>>(_domainService.Domain() + "api/ToDoLists/");
        return response;
    }
}
