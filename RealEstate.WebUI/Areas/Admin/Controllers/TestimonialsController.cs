using Microsoft.AspNetCore.Mvc;
using RealEstate.WebUI.ApiClients.Abstracts;
using RealEstate.WebUI.Dtos.TestimonialDtos;

namespace RealEstate.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class TestimonialsController : Controller
{
    private readonly ITestimonialApiClient _apiClient;

    public TestimonialsController(ITestimonialApiClient testimonialApiClient)
    {
        _apiClient = testimonialApiClient;
    }

    public async Task<IActionResult> Index()
    {
        List<ResultTestimonialDto> testimonials = await _apiClient.GetAllAsync();
        if (testimonials is not null)
            return View(testimonials);
        return View();
    }

    [HttpGet]
    public IActionResult CreateTestimonial()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto testimonialDto)
    {
        await _apiClient.AddAsync(testimonialDto);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> DeleteTestimonial(int id)
    {
        bool isSuccess = await _apiClient.DeleteAsync(id);
        if (isSuccess)
            return RedirectToAction(nameof(Index));
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> UpdateTestimonial(int id)
    {
        UpdateTestimonialDto testimonial = await _apiClient.GetUpdateAsync(id);
        if (testimonial is not null)
            return View(testimonial);
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto testimonialDto)
    {
        bool isSuccess = await _apiClient.UpdateAsync(testimonialDto);
        if (isSuccess)
            return RedirectToAction(nameof(Index));
        return View();
    }
}
