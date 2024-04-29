using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.WebUI.ApiClients.Abstracts;
using RealEstate.WebUI.Dtos.EmployeeDtos;

namespace RealEstate.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
public class EmployeesController : Controller
{
    private readonly IEmployeeApiClient _apiClient;

    public EmployeesController(IEmployeeApiClient employeeApiClient)
    {
        _apiClient = employeeApiClient;
    }
    public async Task<IActionResult> Index()
    {
        List<ResultEmployeeDto> employees = await _apiClient.GetAllAsync();
        if (employees is not null)
            return View(employees);
        return View();
    }

    [HttpGet]
    public IActionResult CreateEmployee()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployee(CreateEmployeeDto employeeDto)
    {
        await _apiClient.AddAsync(employeeDto);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult DeleteEmployee(int id)
    {
        _apiClient.Delete(id);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> UpdateEmployee(int id)
    {
        UpdateEmployeeDto employee = await _apiClient.GetUpdateAsync(id);
        if (employee is not null)
            return View(employee);
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDto employeeDto)
    {
        bool isSuccess = await _apiClient.UpdateAsync(employeeDto);
        if (isSuccess)
            return RedirectToAction(nameof(Index));
        return View();
    }
}