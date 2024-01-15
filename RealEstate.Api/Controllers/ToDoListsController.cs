using Microsoft.AspNetCore.Mvc;
using RealEstate.Api.Dtos.ToDoListDtos;
using RealEstate.Api.Repositories.ToDoListRepository;

namespace RealEstate.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ToDoListsController : ControllerBase
{
    private readonly IToDoListRepository _toDoListRepository;

    public ToDoListsController(IToDoListRepository toDoListRepository)
    {
        _toDoListRepository = toDoListRepository;
    }

    [HttpGet]
    public async Task<IActionResult> ToDoList()
    {
        List<ResultToDoListDto> toDoList = await _toDoListRepository.GetAllToDoListAsync();
        return Ok(toDoList);
    }
}
