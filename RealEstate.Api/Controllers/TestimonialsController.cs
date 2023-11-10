using Microsoft.AspNetCore.Mvc;
using RealEstate.Api.Dtos.TestimonialDtos;
using RealEstate.Api.Repositories.TestimonialRepository;

namespace RealEstate.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestimonialsController : ControllerBase
{
    private readonly ITestimonialRepository _testimonialRepository;

    public TestimonialsController(ITestimonialRepository testimonialRepository)
    {
        _testimonialRepository = testimonialRepository;
    }

    [HttpGet]
    public async Task<IActionResult> TestimonialList()
    {
        List<ResultTestimonialDto> testimonials = await _testimonialRepository.GetAllTestimonialAsync();
        return Ok(testimonials);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> TestimonialById(int id)
    {
        GetByIdTestimonialDto testimonial = await _testimonialRepository.GetTestimonialAsync(id);
        return Ok(testimonial);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto testimonialDto)
    {
        CreateTestimonialDto testimonial = await _testimonialRepository.CreateTestimonialAsync(testimonialDto);
        return Ok(testimonial);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTestimonialy(int id)
    {
        GetByIdTestimonialDto testimonial = _testimonialRepository.GetTestimonial(id);
        _testimonialRepository.DeleteTestimonial(testimonial);
        return Ok("Referans Başarılı Bir Şekilde Silindi!");

    }

    [HttpPut]
    public IActionResult UpdateTestimonial(UpdateTestimonialDto testimonialDto)
    {
        _testimonialRepository.UpdateTestimonial(testimonialDto);
        return Ok("Referans Başarılı Bir Şekilde Güncellendi!");
    }
}
