using RealEstate.Api.Dtos.TestimonialDtos;

namespace RealEstate.Api.Repositories.TestimonialRepository;

public interface ITestimonialRepository
{
    Task<List<ResultTestimonialDto>> GetAllTestimonialAsync();
    Task<GetByIdTestimonialDto> GetTestimonialAsync(int id);
    GetByIdTestimonialDto GetTestimonial(int id);
    Task<CreateTestimonialDto> CreateTestimonialAsync (CreateTestimonialDto testimonialDto);
    void UpdateTestimonial (UpdateTestimonialDto testimonialDto);
    void DeleteTestimonial (GetByIdTestimonialDto testimonialDto);
}
