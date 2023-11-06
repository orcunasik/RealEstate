using Dapper;
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
        using (var connection = _context.CreateConnection())
        {
            int employeeId = await connection.QuerySingleAsync<int>(insertQuery, parameters);
            string selectQuery = "Select * From Employess Where EmployeeId = @employeeId";
            CreateEmployeeDto employee = await connection.QuerySingleOrDefaultAsync<CreateEmployeeDto>(selectQuery, new { employeeId });
            return employee;
        }
    }

    public async Task DeleteEmployeeAsync(int id)
    {
        using (var connection = _context.CreateConnection())
        {
            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    string deleteProductDetailQuery = "DELETE FROM ProductDetail WHERE ProductId IN (SELECT ProductId FROM Products WHERE EmployeeId = @employeeId)";
                    DynamicParameters productDetailParameters = new();
                    productDetailParameters.Add("@employeeId", id);
                    await connection.ExecuteAsync(deleteProductDetailQuery, productDetailParameters, transaction);

                    string deleteProductsQuery = "DELETE FROM Products WHERE EmployeeId = @employeeId";
                    DynamicParameters productsParameters = new();
                    productsParameters.Add("@employeeId", id);
                    await connection.ExecuteAsync(deleteProductsQuery, productsParameters, transaction);

                    string deleteEmployeeQuery = "DELETE FROM Employees WHERE EmployeeId = @employeeId";
                    DynamicParameters employeeParameters = new();
                    employeeParameters.Add("@employeeId", id);
                    await connection.ExecuteAsync(deleteEmployeeQuery, employeeParameters, transaction);

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw new Exception("Employee silme işlemi başarısız oldu.");
                }
            }
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
        DynamicParameters parameters = new();
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
