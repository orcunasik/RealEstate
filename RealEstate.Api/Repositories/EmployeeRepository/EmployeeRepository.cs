using Dapper;
using RealEstate.Api.Dtos.EmployeeDtos;
using RealEstate.Api.Models.DapperContext;
using System.Data;

namespace RealEstate.Api.Repositories.EmployeeRepository;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly BaseContext _context;

    public EmployeeRepository(BaseContext context)
    {
        _context = context;
    }
    public async Task<CreateEmployeeDto> CreateEmployeeAsync(CreateEmployeeDto employeeDto)
    {
        string insertQuery = "Insert into Employees (Name,Title,Email,PhoneNumber,ImageUrl,Status) values (@name,@title,@email,@phoneNumber,@imageUrl,@status);SELECT SCOPE_IDENTITY()";
        DynamicParameters parameters = new();
        parameters.Add("@name", employeeDto.Name);
        parameters.Add("@title", employeeDto.Title);
        parameters.Add("@email", employeeDto.Email);
        parameters.Add("@phoneNumber", employeeDto.PhoneNumber);
        parameters.Add("@imageUrl", employeeDto.ImageUrl);
        parameters.Add("@status", true);
        using (IDbConnection connection = _context.CreateConnection())
        {
            int employeeId = await connection.QuerySingleAsync<int>(insertQuery, parameters);
            string selectQuery = "Select * From Employees Where EmployeeId = @employeeId";
            CreateEmployeeDto employee = await connection.QuerySingleOrDefaultAsync<CreateEmployeeDto>(selectQuery, new { employeeId });
            return employee;
        }
    }

    public async void DeleteEmployee(GetByIdEmployeeDto employeeDto)
    {
        string deleteQuery = "DELETE FROM ProductDetails WHERE ProductId IN (SELECT ProductId FROM Products WHERE EmployeeId = @employeeId); DELETE FROM Products WHERE EmployeeId = @employeeId;DELETE FROM Employees Where EmployeeId = @employeeId";
        DynamicParameters parameter = new();
        parameter.Add("@employeeId", employeeDto.EmployeeId);
        
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(deleteQuery, parameter);
        }
    }

    public async Task<List<ResultEmployeeDto>> GetAllEmployeeAsync()
    {
        string listQuery = "Select * From Employees";
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<ResultEmployeeDto> employees = await connection.QueryAsync<ResultEmployeeDto>(listQuery);
            return employees.ToList();
        }
    }

    public async Task<GetByIdEmployeeDto> GetEmployeeAsync(int id)
    {
        string getByIdQuery = "Select * From Employees Where EmployeeId = @employeeId";
        DynamicParameters parameter = new();
        parameter.Add("@employeeId", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            dynamic employee = await connection.QueryFirstOrDefaultAsync<GetByIdEmployeeDto>(getByIdQuery, parameter);
            return employee;
        }
    }

    public GetByIdEmployeeDto GetEmployee(int id)
    {
        string getByIdQuery = "Select * From Employees Where EmployeeId = @employeeId";
        DynamicParameters parameter = new();
        parameter.Add("@employeeId", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            dynamic employee = connection.QueryFirstOrDefault<GetByIdEmployeeDto>(getByIdQuery, parameter);
            return employee;
        }
    }

    public async void UpdateEmployee(UpdateEmployeeDto employeeDto)
    {
        string updateQuery = "Update Employees Set Name = @name,Title = @title, Email = @email, PhoneNumber = @phoneNumber, ImageUrl = @imageUrl, Status = @status Where EmployeeId = @employeeId";
        DynamicParameters parameters = new();
        parameters.Add("@employeeId", employeeDto.EmployeeId);
        parameters.Add("@name", employeeDto.Name);
        parameters.Add("@title", employeeDto.Title);
        parameters.Add("@email", employeeDto.Email);
        parameters.Add("@phoneNumber", employeeDto.PhoneNumber);
        parameters.Add("@imageUrl", employeeDto.ImageUrl);
        parameters.Add("@status", employeeDto.Status);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(updateQuery, parameters);
        }
    }
}
