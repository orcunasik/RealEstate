using RealEstate.WebUI.Dtos.ContactDtos;

namespace RealEstate.WebUI.ApiClients.Abstracts;

public interface IContactApiClient
{
    Task<List<LastContactResultDto>> GetLastContactsAsync();
}
