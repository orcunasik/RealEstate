using RealEstate.WebUI.Dtos.CategoryDtos;
using RealEstate.WebUI.Dtos.TestimonialDtos;

namespace RealEstate.WebUI.ApiClients.Abstracts;

public interface ITestimonialApiClient
{
    Task<List<ResultTestimonialDto>> GetAllAsync();
    Task<UpdateTestimonialDto> GetUpdateAsync(int id);
    Task<CreateTestimonialDto> AddAsync(CreateTestimonialDto testimonialDto);
    Task<bool> UpdateAsync(UpdateTestimonialDto testimonialDto);
    Task<bool> DeleteAsync(int id);
}