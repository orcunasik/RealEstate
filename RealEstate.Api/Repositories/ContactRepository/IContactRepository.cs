using RealEstate.Api.Dtos.ContactDtos;

namespace RealEstate.Api.Repositories.ContactRepository;

public interface IContactRepository
{
    Task<List<ResultContactDto>> GetAllContactAsync();
    Task<List<LastContactResultDto>> GetLastContactsAsync();
    Task<GetByIdContactDto> GetContactAsync(int id);
    Task<CreateContactDto> CreateContactAsync(CreateContactDto contactDto);
    void DeleteContact(GetByIdContactDto contactDto);
}