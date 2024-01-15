using RealEstate.WebUI.Dtos.ToDoListDtos;

namespace RealEstate.WebUI.ApiClients.Abstracts;

public interface IToDoListApiClient
{
    Task<List<ResultToDoListDto>> GetAllToDoListAsync();
}