using RealEstate.Api.Dtos.EmployeeDtos;

namespace RealEstate.Api.Repositories.EmployeeRepository;

public interface IEmployeeRepository
{
    Task<List<ResultEmployeeDto>> GetAllEmployeeAsync();
    Task<GetByIdEmployeeDto> GetEmployeeAsync(int id);
    void CreateEmployee(CreateEmployeeDto employeeDto);
    void DeleteEmployee(int id);
    void UpdateEmployee(UpdateEmployeeDto employeeDto);
}
