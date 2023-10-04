using Microsoft.AspNetCore.Mvc;
using RealEstate.Api.Dtos.PopularLocationDtos;
using RealEstate.Api.Repositories.PopularLocationRepository;

namespace RealEstate.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PopularLocationsController : ControllerBase
{
    private readonly IPopularLocationRepository _popularLocationRepository;

    public PopularLocationsController(IPopularLocationRepository popularLocationRepository)
    {
        _popularLocationRepository = popularLocationRepository;
    }

    [HttpGet]
    public async Task<IActionResult> PopularLocationList()
    {
        var locations = await _popularLocationRepository.GetAllPopularLocationsAsync();
        return Ok(locations);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> PopularLocationById(int id)
    {
        var location = await _popularLocationRepository.GetPopularLocationAsync(id);
        return Ok(location);
    }

    [HttpPost]
    public IActionResult CreatePopularLocation(CreatePopularLocationDto popularLocationDto)
    {
        _popularLocationRepository.CreatePopularLocation(popularLocationDto);
        return Ok("Yeni Lokasyon Bilgisi Başarılı Bir Şekilde Kaydedildi!");
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePopularLocation(int id)
    {
        _popularLocationRepository.DeletePopularLocation(id);
        return Ok("Lokasyon Bilgisi Başarılı Bir Şekilde Silindi!");

    }

    [HttpPut]
    public IActionResult UpdatePopularLocation(UpdatePopularLocationDto popularLocationDto)
    {
        _popularLocationRepository.UpdatePopularLocation(popularLocationDto);
        return Ok("Lokasyon Bilgisi Başarılı Bir Şekilde Güncellendi!");
    }
}
