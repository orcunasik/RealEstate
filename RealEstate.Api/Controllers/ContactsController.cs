using Microsoft.AspNetCore.Mvc;
using RealEstate.Api.Dtos.ContactDtos;
using RealEstate.Api.Repositories.ContactRepository;

namespace RealEstate.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactsController : ControllerBase
{
    private readonly IContactRepository _contactRepository;

    public ContactsController(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    [HttpGet("LastContacts")]
    public async Task<IActionResult> LastContacts()
    {
        List<LastContactResultDto> lastContacts = await _contactRepository.GetLastContactsAsync();
        return Ok(lastContacts);
    }
}
