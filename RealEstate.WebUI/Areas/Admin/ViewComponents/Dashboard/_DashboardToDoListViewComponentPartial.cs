using Microsoft.AspNetCore.Mvc;
using RealEstate.WebUI.ApiClients.Abstracts;
using RealEstate.WebUI.Dtos.ToDoListDtos;

namespace RealEstate.WebUI.Areas.Admin.ViewComponents.Dashboard;

public class _DashboardToDoListViewComponentPartial : ViewComponent
{
    private readonly IToDoListApiClient _toDoListApiClient;

    public _DashboardToDoListViewComponentPartial(IToDoListApiClient toDoListApiClient)
    {
        _toDoListApiClient = toDoListApiClient;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        List<ResultToDoListDto> toDoList = await _toDoListApiClient.GetAllToDoListAsync();
        return View(toDoList);
    }
}