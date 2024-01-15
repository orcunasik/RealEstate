using Dapper;
using RealEstate.Api.Dtos.ToDoListDtos;
using RealEstate.Api.Models.DapperContext;
using System.Data;

namespace RealEstate.Api.Repositories.ToDoListRepository;

public class ToDoListRepository : IToDoListRepository
{
    private readonly BaseContext _context;

    public ToDoListRepository(BaseContext context)
    {
        _context = context;
    }
    public Task<CreateToDoListDto> CreateToDoListAsync(CreateToDoListDto toDoListDto)
    {
        throw new NotImplementedException();
    }

    public void DeleteToDoList(GetByIdToDoListDto toDoListDto)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ResultToDoListDto>> GetAllToDoListAsync()
    {
        string listQuery = "Select * From ToDoLists";
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<ResultToDoListDto> toDoList = await connection.QueryAsync<ResultToDoListDto>(listQuery);
            return toDoList.ToList();
        }
    }

    public Task<GetByIdToDoListDto> GetToDoListAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void UpdateToDoList(UpdateToDoListDto toDoListDto)
    {
        throw new NotImplementedException();
    }
}