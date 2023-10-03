using Microsoft.AspNetCore.Mvc;
using RealEstate.Api.Dtos.WhoWeAreDetailDtos;
using RealEstate.Api.Repositories.WhoWeAreDetailRepository;

namespace RealEstate.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WhoWeAreDetailsController : ControllerBase
{
    private readonly IWhoWeAreDetailRepository _whoWeAreDetailRepository;

    public WhoWeAreDetailsController(IWhoWeAreDetailRepository whoWeAreDetailRepository)
    {
        _whoWeAreDetailRepository = whoWeAreDetailRepository;
    }

    [HttpGet]
    public async Task<IActionResult> WhoWeAreDetailList()
    {
        var whoWeAreDetails = await _whoWeAreDetailRepository.GetAllWhoWeAreDetailAsync();
        return Ok(whoWeAreDetails);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> WhoWeAreDetailById(int id)
    {
        var whoWeAreDetail = await _whoWeAreDetailRepository.GetWhoWeAreDetailAsync(id);
        return Ok(whoWeAreDetail);
    }

    [HttpPost]
    public IActionResult CreateWhoWeAreDetail(CreateWhoWeAreDetailDto whoWeAreDetailDto)
    {
        _whoWeAreDetailRepository.CreateWhoWeAreDetail(whoWeAreDetailDto);
        return Ok("Hakkımızda Alanı Başarılı Bir Şekilde Eklendi!");
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteWhoWeAreDetail(int id)
    {
        _whoWeAreDetailRepository.DeleteWhoWeAreDetail(id);
        return Ok("Hakkımızda Alanı Başarılı Bir Şekilde Silindi!");

    }

    [HttpPut]
    public IActionResult UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto whoWeAreDetailDto)
    {
        _whoWeAreDetailRepository.UpdateWhoWeAreDetail(whoWeAreDetailDto);
        return Ok("Hakkımızda Alanı Başarılı Bir Şekilde Güncellendi!");
    }
}
