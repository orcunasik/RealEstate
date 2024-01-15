using RealEstate.WebUI.ApiClients.Abstracts;
using RealEstate.WebUI.Configurations;
using RealEstate.WebUI.Dtos.CategoryDtos;
using RealEstate.WebUI.Dtos.ContactDtos;

namespace RealEstate.WebUI.ApiClients.Concretes;

public class ContactApiClient : IContactApiClient
{
    private readonly IHttpClientFactory _httpClient;
    private readonly IDomainService _domainService;
    public ContactApiClient(IHttpClientFactory httpClient, IDomainService domainService)
    {
        _httpClient = httpClient;
        _domainService = domainService;
    }
    public async Task<List<LastContactResultDto>> GetLastContactsAsync()
    {
        HttpClient client = _httpClient.CreateClient();
        List<LastContactResultDto>? response = await client.GetFromJsonAsync<List<LastContactResultDto>>(_domainService.Domain() + "api/Contacts/LastContacts");
        return response;
    }
}
