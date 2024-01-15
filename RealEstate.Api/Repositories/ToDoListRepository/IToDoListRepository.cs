using RealEstate.Api.Dtos.ToDoListDtos;

namespace RealEstate.Api.Repositories.ToDoListRepository;

public interface IToDoListRepository
{
    Task<List<ResultToDoListDto>> GetAllToDoListAsync();
    Task<GetByIdToDoListDto> GetToDoListAsync(int id);
    Task<CreateToDoListDto> CreateToDoListAsync(CreateToDoListDto toDoListDto);
    void UpdateToDoList(UpdateToDoListDto toDoListDto);
    void DeleteToDoList(GetByIdToDoListDto toDoListDto);
}