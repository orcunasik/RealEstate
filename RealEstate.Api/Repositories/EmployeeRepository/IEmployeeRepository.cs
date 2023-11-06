using RealEstate.Api.Dtos.EmployeeDtos;

namespace RealEstate.Api.Repositories.EmployeeRepository;

public interface IEmployeeRepository
{
    Task<List<ResultEmployeeDto>> GetAllEmployeeAsync();
    Task<GetByIdEmployeeDto> GetEmployeeAsync(int id);
    Task<CreateEmployeeDto> CreateEmployeeAsync(CreateEmployeeDto employeeDto);
    Task DeleteEmployeeAsync(int id);
    void UpdateEmployee(UpdateEmployeeDto employeeDto);
}
