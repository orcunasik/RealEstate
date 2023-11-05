using RealEstate.WebUI.ApiClients.Abstracts;
using RealEstate.WebUI.Configurations;
using RealEstate.WebUI.Dtos.EmployeeDtos;

namespace RealEstate.WebUI.ApiClients.Concretes;

public class EmployeeApiClient : IEmployeeApiClient
{
    private readonly IHttpClientFactory _httpClient;
    private readonly IDomainService _domainService;
    public EmployeeApiClient(IHttpClientFactory httpClient, IDomainService domainService)
    {
        _httpClient = httpClient;
        _domainService = domainService;
    }

    public async Task<CreateEmployeeDto> AddAsync(CreateEmployeeDto employeeDto)
    {
        HttpClient client = _httpClient.CreateClient();
        HttpResponseMessage response = await client.PostAsJsonAsync(_domainService.Domain() + "api/Employees", employeeDto);
        if (response.IsSuccessStatusCode)
            return await response.Content.ReadFromJsonAsync<CreateEmployeeDto>();
        return null;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        HttpClient client = _httpClient.CreateClient();
        HttpResponseMessage response = await client.DeleteAsync(_domainService.Domain() + $"api/Employees/{id}");

        return response.IsSuccessStatusCode;
    }

    public async Task<List<ResultEmployeeDto>> GetAllAsync()
    {
        HttpClient client = _httpClient.CreateClient();
        List<ResultEmployeeDto>? response = await client.GetFromJsonAsync<List<ResultEmployeeDto>>(_domainService.Domain() + "api/Employees");
        return response;
    }

    public async Task<UpdateEmployeeDto> GetUpdateAsync(int id)
    {
        HttpClient client = _httpClient.CreateClient();
        UpdateEmployeeDto? response = await client.GetFromJsonAsync<UpdateEmployeeDto>(_domainService.Domain() + $"api/Employees/{id}");
        return response;
    }

    public async Task<bool> UpdateAsync(UpdateEmployeeDto employeeDto)
    {
        HttpClient client = _httpClient.CreateClient();
        HttpResponseMessage response = await client.PutAsJsonAsync(_domainService.Domain() + $"api/Employees/{employeeDto.EmployeeId}", employeeDto);
        return response.IsSuccessStatusCode;
    }
}