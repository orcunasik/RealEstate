using RealEstate.Api.Dtos.EmployeeDtos;

namespace RealEstate.Api.Repositories.EmployeeRepository;

public interface IEmployeeRepository
{
    Task<List<ResultEmployeeDto>> GetAllEmployeeAsync();
    Task<GetByIdEmployeeDto> GetEmployeeAsync(int id);
    GetByIdEmployeeDto GetEmployee(int id);
    Task<CreateEmployeeDto> CreateEmployeeAsync(CreateEmployeeDto employeeDto);
    void DeleteEmployee(GetByIdEmployeeDto employeeDto);
    void UpdateEmployee(UpdateEmployeeDto employeeDto);
}
