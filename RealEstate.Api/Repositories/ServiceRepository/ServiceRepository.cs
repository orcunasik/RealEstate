using Dapper;
using RealEstate.Api.Dtos.ServiceDtos;
using RealEstate.Api.Models.DapperContext;

namespace RealEstate.Api.Repositories.ServiceRepository;

public class ServiceRepository : IServiceRepository
{
    private readonly BaseContext _context;

    public ServiceRepository(BaseContext context)
    {
        _context = context;
    }

    public async void CreateService(CreateServiceDto serviceDto)
    {
        string query = "Insert into Services (ServiceName,ServiceStatus) values (@serviceName,@serviceStatus)";
        var parameters = new DynamicParameters();
        parameters.Add("@serviceName", serviceDto.ServiceName);
        parameters.Add("@serviceStatus", serviceDto.ServiceStatus);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async void DeleteService(int id)
    {
        string query = "Delete From Services Where ServiceId = @serviceId";
        var parameters = new DynamicParameters();
        parameters.Add("@serviceId", id);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<List<ResultServiceDto>> GetAllServiceAsync()
    {
        string query = "Select * From Services";
        using (var connection = _context.CreateConnection())
        {
            var services = await connection.QueryAsync<ResultServiceDto>(query);
            return services.ToList();
        }
    }

    public async Task<GetByIdServiceDto> GetServiceAsync(int id)
    {
        string query = "Select * From Services Where ServiceId = @serviceId";
        var parameters = new DynamicParameters();
        parameters.Add("@serviceId", id);
        using (var connection = _context.CreateConnection())
        {
            dynamic service = await connection.QueryFirstOrDefaultAsync<GetByIdServiceDto>(query, parameters);
            return service;
        }
    }

    public async void UpdateService(UpdateServiceDto serviceDto)
    {
        string query = "Update Services Set ServiceName = @serviceName, ServiceStatus = @serviceStatus Where ServiceId = @serviceId";
        var parameters = new DynamicParameters();
        parameters.Add("@serviceId", serviceDto.ServiceId);
        parameters.Add("@serviceName", serviceDto.ServiceName);
        parameters.Add("@serviceStatus", serviceDto.ServiceStatus);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
