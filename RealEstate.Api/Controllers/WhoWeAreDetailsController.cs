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
        List<ResultWhoWeAreDetailDto> whoWeAreDetails = await _whoWeAreDetailRepository.GetAllWhoWeAreDetailAsync();
        return Ok(whoWeAreDetails);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> WhoWeAreDetailById(int id)
    {
        GetByIdWhoWeAreDetailDto whoWeAreDetail = await _whoWeAreDetailRepository.GetWhoWeAreDetailAsync(id);
        return Ok(whoWeAreDetail);
    }

    [HttpPost]
    public async Task<IActionResult> CreateWhoWeAreDetail(CreateWhoWeAreDetailDto whoWeAreDetailDto)
    {
        CreateWhoWeAreDetailDto whoWeAreDetail = await _whoWeAreDetailRepository.CreateWhoWeAreDetailAsync(whoWeAreDetailDto);
        return Ok(whoWeAreDetail);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteWhoWeAreDetail(int id)
    {
        GetByIdWhoWeAreDetailDto whoWeAreDetail = _whoWeAreDetailRepository.GetWhoWeAreDetail(id);
        _whoWeAreDetailRepository.DeleteWhoWeAreDetail(whoWeAreDetail);
        return Ok("Hakkımızda Alanı Başarılı Bir Şekilde Silindi!");

    }

    [HttpPut]
    public IActionResult UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto whoWeAreDetailDto)
    {
        _whoWeAreDetailRepository.UpdateWhoWeAreDetail(whoWeAreDetailDto);
        return Ok("Hakkımızda Alanı Başarılı Bir Şekilde Güncellendi!");
    }
}
