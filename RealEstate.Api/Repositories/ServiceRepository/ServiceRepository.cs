using Dapper;
using RealEstate.Api.Dtos.ServiceDtos;
using RealEstate.Api.Models.DapperContext;
using System.Data;

namespace RealEstate.Api.Repositories.ServiceRepository;

public class ServiceRepository : IServiceRepository
{
    private readonly BaseContext _context;

    public ServiceRepository(BaseContext context)
    {
        _context = context;
    }

    public async Task<CreateServiceDto> CreateServiceAsync(CreateServiceDto serviceDto)
    {
        string insertQuery = "Insert into Services (ServiceName,ServiceStatus) values (@serviceName,@serviceStatus);SELECT SCOPE_IDENTITY()";
        DynamicParameters parameters = new();
        parameters.Add("@serviceName", serviceDto.ServiceName);
        parameters.Add("@serviceStatus", serviceDto.ServiceStatus);
        using (IDbConnection connection = _context.CreateConnection())
        {
            int serviceId = await connection.QuerySingleAsync<int>(insertQuery, parameters);
            string selectQuery = "Select * From Services Where ServiceId = @serviceId";
            CreateServiceDto service = await connection.QuerySingleOrDefaultAsync<CreateServiceDto>(selectQuery, new { serviceId });
            return service;
        }
    }

    public async void DeleteService(GetByIdServiceDto serviceDto)
    {
        string deleteQuery = "Delete From Services Where ServiceId = @serviceId";
        DynamicParameters parameter = new();
        parameter.Add("@serviceId", serviceDto.ServiceId);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(deleteQuery, parameter);
        }
    }

    public async Task<List<ResultServiceDto>> GetAllServiceAsync()
    {
        string listQuery = "Select * From Services";
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<ResultServiceDto> services = await connection.QueryAsync<ResultServiceDto>(listQuery);
            return services.ToList();
        }
    }

    public GetByIdServiceDto GetService(int id)
    {
        string getByIdQuery = "Select * From Services Where ServiceId = @serviceId";
        DynamicParameters parameter = new();
        parameter.Add("@serviceId", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            dynamic service = connection.QueryFirstOrDefault<GetByIdServiceDto>(getByIdQuery, parameter);
            return service;
        }
    }

    public async Task<GetByIdServiceDto> GetServiceAsync(int id)
    {
        string getByIdQuery = "Select * From Services Where ServiceId = @serviceId";
        DynamicParameters parameter = new();
        parameter.Add("@serviceId", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            dynamic service = await connection.QueryFirstOrDefaultAsync<GetByIdServiceDto>(getByIdQuery, parameter);
            return service;
        }
    }

    public async void UpdateService(UpdateServiceDto serviceDto)
    {
        string updateQuery = "Update Services Set ServiceName = @serviceName, ServiceStatus = @serviceStatus Where ServiceId = @serviceId";
        DynamicParameters parameters = new();
        parameters.Add("@serviceId", serviceDto.ServiceId);
        parameters.Add("@serviceName", serviceDto.ServiceName);
        parameters.Add("@serviceStatus", serviceDto.ServiceStatus);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(updateQuery, parameters);
        }
    }
}
