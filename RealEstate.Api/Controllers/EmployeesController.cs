using Microsoft.AspNetCore.Mvc;
using RealEstate.Api.Dtos.EmployeeDtos;
using RealEstate.Api.Repositories.EmployeeRepository;

namespace RealEstate.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeesController(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    [HttpGet]
    public async Task<IActionResult> EmployeeList()
    {
        List<ResultEmployeeDto> employees = await _employeeRepository.GetAllEmployeeAsync();
        return Ok(employees);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> EmployeeById(int id)
    {
        GetByIdEmployeeDto employee = await _employeeRepository.GetEmployeeAsync(id);
        return Ok(employee);
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployee(CreateEmployeeDto employeeDto)
    {
        CreateEmployeeDto employee = await _employeeRepository.CreateEmployeeAsync(employeeDto);
        return Ok(employee);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteEmployee(int id)
    {
        GetByIdEmployeeDto employee = _employeeRepository.GetEmployee(id);
        _employeeRepository.DeleteEmployee(employee);
        return Ok("Personel Başarılı Bir Şekilde Silindi!");

    }

    [HttpPut]
    public IActionResult UpdateEmployee(UpdateEmployeeDto employeeDto)
    {
        _employeeRepository.UpdateEmployee(employeeDto);
        return Ok("Personel Başarılı Bir Şekilde Güncellendi!");
    }
}
