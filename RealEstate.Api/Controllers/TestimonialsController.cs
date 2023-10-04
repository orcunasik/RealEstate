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
        var testimonials = await _testimonialRepository.GetAllTestimonialAsync();
        return Ok(testimonials);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> TestimonialById(int id)
    {
        var testimonial = await _testimonialRepository.GetTestimonialAsync(id);
        return Ok(testimonial);
    }

    [HttpPost]
    public IActionResult CreateTestimonial(CreateTestimonialDto testimonialDto)
    {
        _testimonialRepository.CreateTestimonial(testimonialDto);
        return Ok("Referans Başarılı Bir Şekilde Eklendi!");
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTestimonialy(int id)
    {
        _testimonialRepository.DeleteTestimonial(id);
        return Ok("Referans Başarılı Bir Şekilde Silindi!");

    }

    [HttpPut]
    public IActionResult UpdateTestimonial(UpdateTestimonialDto testimonialDto)
    {
        _testimonialRepository.UpdateTestimonial(testimonialDto);
        return Ok("Referans Başarılı Bir Şekilde Güncellendi!");
    }
}
