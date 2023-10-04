using RealEstate.Api.Dtos.TestimonialDtos;

namespace RealEstate.Api.Repositories.TestimonialRepository;

public interface ITestimonialRepository
{
    Task<List<ResultTestimonialDto>> GetAllTestimonialAsync();
    Task<GetByIdTestimonialDto> GetTestimonialAsync(int id);
    void CreateTestimonial (CreateTestimonialDto testimonialDto);
    void UpdateTestimonial (UpdateTestimonialDto testimonialDto);
    void DeleteTestimonial (int id);
}
