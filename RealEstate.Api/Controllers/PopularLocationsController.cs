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
        List<ResultPopularLocationDto> popularLocations = await _popularLocationRepository.GetAllPopularLocationsAsync();
        return Ok(popularLocations);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> PopularLocationById(int id)
    {
        GetByIdPopularLocationDto popularLocation = await _popularLocationRepository.GetPopularLocationAsync(id);
        return Ok(popularLocation);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePopularLocation(CreatePopularLocationDto popularLocationDto)
    {
        CreatePopularLocationDto popularLocation = await _popularLocationRepository.CreatePopularLocationAsync(popularLocationDto);
        return Ok(popularLocation);
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePopularLocation(int id)
    {
        GetByIdPopularLocationDto popularLocation = _popularLocationRepository.GetPopularLocation(id);
        _popularLocationRepository.DeletePopularLocation(popularLocation);
        return Ok("Lokasyon Bilgisi Başarılı Bir Şekilde Silindi!");

    }

    [HttpPut]
    public IActionResult UpdatePopularLocation(UpdatePopularLocationDto popularLocationDto)
    {
        _popularLocationRepository.UpdatePopularLocation(popularLocationDto);
        return Ok("Lokasyon Bilgisi Başarılı Bir Şekilde Güncellendi!");
    }
}
