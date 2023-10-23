using Dapper;
using RealEstate.Api.Dtos.CategoryDtos;
using RealEstate.Api.Dtos.EmployeeDtos;
using RealEstate.Api.Models.DapperContext;

namespace RealEstate.Api.Repositories.EmployeeRepository;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly BaseContext _context;

    public EmployeeRepository(BaseContext context)
    {
        _context = context;
    }
    public async void CreateEmployee(CreateEmployeeDto employeeDto)
    {
        string query = "Insert into Employees (Name,Title,Email,PhoneNumber,ImageUrl,Status) values (@name,@title,@email,@phoneNumber,@imageUrl,@status)";
        var parameters = new DynamicParameters();
        parameters.Add("@name", employeeDto.Name);
        parameters.Add("@title", employeeDto.Title);
        parameters.Add("@email", employeeDto.Email);
        parameters.Add("@phoneNumber", employeeDto.PhoneNumber);
        parameters.Add("@imageUrl", employeeDto.ImageUrl);
        parameters.Add("@status", true);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async void DeleteEmployee(int id)
    {
        string query = "Delete From Employees Where EmployeeId = @employeeId";
        var parameters = new DynamicParameters();
        parameters.Add("@employeeId", id);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<List<ResultEmployeeDto>> GetAllEmployeeAsync()
    {
        string query = "Select * From Employees";
        using (var connection = _context.CreateConnection())
        {
            var employees = await connection.QueryAsync<ResultEmployeeDto>(query);
            return employees.ToList();
        }
    }

    public async Task<GetByIdEmployeeDto> GetEmployeeAsync(int id)
    {
        string query = "Select * From Employees Where EmployeeId = @employeeId";
        var parameters = new DynamicParameters();
        parameters.Add("@employeeId", id);
        using (var connection = _context.CreateConnection())
        {
            dynamic employee = await connection.QueryFirstOrDefaultAsync<GetByIdEmployeeDto>(query, parameters);
            return employee;
        }
    }

    public async void UpdateEmployee(UpdateEmployeeDto employeeDto)
    {
        string query = "Update Employees Set Name = @name,Title = @title, Email = @email, PhoneNumber = @phoneNumber, ImageUrl = @imageUrl, Status = @status Where EmployeeId = @employeeId";
        var parameters = new DynamicParameters();
        parameters.Add("@employeeId", employeeDto.EmployeeId);
        parameters.Add("@name", employeeDto.Name);
        parameters.Add("@title", employeeDto.Title);
        parameters.Add("@email", employeeDto.Email);
        parameters.Add("@phoneNumber", employeeDto.PhoneNumber);
        parameters.Add("@imageUrl", employeeDto.ImageUrl);
        parameters.Add("@status", employeeDto.Status);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
