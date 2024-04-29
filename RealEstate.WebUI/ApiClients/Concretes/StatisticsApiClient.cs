using RealEstate.WebUI.ApiClients.Abstracts;
using RealEstate.WebUI.Configurations;

namespace RealEstate.WebUI.ApiClients.Concretes;

public class StatisticsApiClient : IStatisticsApiClient
{
    private readonly IHttpClientFactory _httpClient;
    private readonly IDomainService _domainService;
    public StatisticsApiClient(IHttpClientFactory httpClient, IDomainService domainService)
    {
        _httpClient = httpClient;
        _domainService = domainService;
    }
    public async Task<int> GetActiveCategoryCountAsync()
    {
        HttpClient client = _httpClient.CreateClient();
        int response = await client.GetFromJsonAsync<int>(_domainService.Domain() + "api/Statistics/ActiveCategoryCount");
        return response;
    }

    public async Task<int> GetActiveEmployeeCountAsync()
    {
        HttpClient client = _httpClient.CreateClient();
        int response = await client.GetFromJsonAsync<int>(_domainService.Domain() + "api/Statistics/ActiveEmployeeCount");
        return response;
    }

    public async Task<int> GetApartmentCountAsync()
    {
        HttpClient client = _httpClient.CreateClient();
        int response = await client.GetFromJsonAsync<int>(_domainService.Domain() + "api/Statistics/ApartmentCount");
        return response;
    }

    public async Task<decimal> GetAvgProductPriceByRentAsync()
    {
        HttpClient client = _httpClient.CreateClient();
        decimal response = await client.GetFromJsonAsync<decimal>(_domainService.Domain() + "api/Statistics/AvgProductPriceByRent");
        return response;
    }

    public async Task<decimal> GetAvgProductPriceBySaleAsync()
    {
        HttpClient client = _httpClient.CreateClient();
        decimal response = await client.GetFromJsonAsync<decimal>(_domainService.Domain() + "api/Statistics/AvgProductPriceBySale");
        return response;
    }

    public async Task<int> GetAvgRoomCountAsync()
    {
        HttpClient client = _httpClient.CreateClient();
        int response = await client.GetFromJsonAsync<int>(_domainService.Domain() + "api/Statistics/AvgRoomCount");
        return response;
    }

    public async Task<int> GetCategoryCountAsync()
    {
        HttpClient client = _httpClient.CreateClient();
        int response = await client.GetFromJsonAsync<int>(_domainService.Domain() + "api/Statistics/CategoryCount");
        return response;
    }

    public async Task<string> GetCategoryNameByMaxProductCountAsync()
    {
        HttpClient client = _httpClient.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync(_domainService.Domain() + "api/Statistics/CategoryNameByMaxProductCount");
        string jsonResult = await responseMessage.Content.ReadAsStringAsync();
        return jsonResult;
    }

    public async Task<string> GetCityNameByMaxProductCountAsync()
    {
        HttpClient client = _httpClient.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync(_domainService.Domain() + "api/Statistics/CityNameByMaxProductCount");
        string jsonResult = await responseMessage.Content.ReadAsStringAsync();
        return jsonResult;
    }

    public async Task<int> GetDifferentCityCountAsync()
    {
        HttpClient client = _httpClient.CreateClient();
        int response = await client.GetFromJsonAsync<int>(_domainService.Domain() + "api/Statistics/DifferentCityCount");
        return response;
    }

    public async Task<string> GetEmployeeNameByMaxProductCountAsync()
    {
        HttpClient client = _httpClient.CreateClient();
        string? response = await client.GetFromJsonAsync<string>(_domainService.Domain() + "api/Statistics/EmployeeNameByMaxProductCount");
        return response;
    }

    public async Task<decimal> GetLastProdcutPriceAsync()
    {
        HttpClient client = _httpClient.CreateClient();
        decimal response = await client.GetFromJsonAsync<decimal>(_domainService.Domain() + "api/Statistics/LastProdcutPrice");
        return response;
    }

    public async Task<string> GetNewestBuildingYearAsync()
    {
        HttpClient client = _httpClient.CreateClient();
        string? response = await client.GetFromJsonAsync<string>(_domainService.Domain() + "api/Statistics/NewestBuildingYear");
        return response;
    }

    public async Task<string> GetOldestBuildingYearAsync()
    {
        HttpClient client = _httpClient.CreateClient();
        string? response = await client.GetFromJsonAsync<string>(_domainService.Domain() + "api/Statistics/OldestBuildingYear");
        return response;
    }

    public async Task<int> GetPassiveCategoryCountAsync()
    {
        HttpClient client = _httpClient.CreateClient();
        int response = await client.GetFromJsonAsync<int>(_domainService.Domain() + "api/Statistics/PassiveCategoryCount");
        return response;
    }

    public async Task<int> GetProductCountAsync()
    {
        HttpClient client = _httpClient.CreateClient();
        int response = await client.GetFromJsonAsync<int>(_domainService.Domain() + "api/Statistics/ProductCount");
        return response;
    }
}