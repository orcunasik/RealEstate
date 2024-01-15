using Dapper;
using RealEstate.Api.Dtos.ContactDtos;
using RealEstate.Api.Models.DapperContext;
using System.Data;

namespace RealEstate.Api.Repositories.ContactRepository;

public class ContactRepository : IContactRepository
{
    private readonly BaseContext _context;

    public ContactRepository(BaseContext context)
    {
        _context = context;
    }
    public Task<CreateContactDto> CreateContactAsync(CreateContactDto contactDto)
    {
        throw new NotImplementedException();
    }

    public void DeleteContact(GetByIdContactDto contactDto)
    {
        throw new NotImplementedException();
    }

    public Task<List<ResultContactDto>> GetAllContactAsync()
    {
        throw new NotImplementedException();
    }

    public Task<GetByIdContactDto> GetContactAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<LastContactResultDto>> GetLastContactsAsync()
    {
        string listQuery = "Select * From Contacts Order By SendDate Desc";
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<LastContactResultDto> contacts = await connection.QueryAsync<LastContactResultDto>(listQuery);
            return contacts.ToList();
        }
    }
}
