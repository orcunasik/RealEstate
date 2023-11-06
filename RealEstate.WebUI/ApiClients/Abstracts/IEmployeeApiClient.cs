using RealEstate.WebUI.Dtos.EmployeeDtos;

namespace RealEstate.WebUI.ApiClients.Abstracts;

public interface IEmployeeApiClient
{
    Task<List<ResultEmployeeDto>> GetAllAsync();
    Task<UpdateEmployeeDto> GetUpdateAsync(int id);
    Task<CreateEmployeeDto> AddAsync(CreateEmployeeDto employeeDto);
    Task<bool> UpdateAsync(UpdateEmployeeDto employeeDto);
    void Delete(int id);
}