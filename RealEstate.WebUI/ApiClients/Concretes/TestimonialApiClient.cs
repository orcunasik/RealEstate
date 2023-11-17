using RealEstate.WebUI.ApiClients.Abstracts;
using RealEstate.WebUI.Configurations;
using RealEstate.WebUI.Dtos.TestimonialDtos;

namespace RealEstate.WebUI.ApiClients.Concretes;

public class TestimonialApiClient : ITestimonialApiClient
{
    private readonly IHttpClientFactory _httpClient;
    private readonly IDomainService _domainService;
    public TestimonialApiClient(IHttpClientFactory httpClient, IDomainService domainService)
    {
        _httpClient = httpClient;
        _domainService = domainService;
    }
    public async Task<CreateTestimonialDto> AddAsync(CreateTestimonialDto testimonialDto)
    {
        HttpClient client = _httpClient.CreateClient();
        HttpResponseMessage response = await client.PostAsJsonAsync(_domainService.Domain() + "api/Testimonials", testimonialDto);
        if (response.IsSuccessStatusCode)
            return await response.Content.ReadFromJsonAsync<CreateTestimonialDto>();
        return null;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        HttpClient client = _httpClient.CreateClient();
        HttpResponseMessage response = await client.DeleteAsync(_domainService.Domain() + $"api/Testimonials/{id}");
        return response.IsSuccessStatusCode;
    }

    public async Task<List<ResultTestimonialDto>> GetAllAsync()
    {
        HttpClient client = _httpClient.CreateClient();
        List<ResultTestimonialDto>? response = await client.GetFromJsonAsync<List<ResultTestimonialDto>>(_domainService.Domain() + "api/Testimonials");
        return response;
    }

    public async Task<UpdateTestimonialDto> GetUpdateAsync(int id)
    {
        HttpClient client = _httpClient.CreateClient();
        UpdateTestimonialDto? response = await client.GetFromJsonAsync<UpdateTestimonialDto>(_domainService.Domain() + $"api/Testimonials/{id}");
        return response;
    }

    public async Task<bool> UpdateAsync(UpdateTestimonialDto testimonialDto)
    {
        HttpClient client = _httpClient.CreateClient();
        HttpResponseMessage response = await client.PutAsJsonAsync(_domainService.Domain() + "api/Testimonials/", testimonialDto);
        return response.IsSuccessStatusCode;
    }
}
