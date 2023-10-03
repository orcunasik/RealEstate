using Microsoft.AspNetCore.Mvc;
using RealEstate.Api.Dtos.BottomGridDtos;
using RealEstate.Api.Repositories.BottomGridRepository;

namespace RealEstate.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BottomGridsController : ControllerBase
{
    private readonly IBottomGridRepository _bottomGridRepository;

    public BottomGridsController(IBottomGridRepository bottomGridRepository)
    {
        _bottomGridRepository = bottomGridRepository;
    }

    [HttpGet]
    public async Task<IActionResult> BottomGridList()
    {
        var bottomGrids = await _bottomGridRepository.GetAllBottomGridAsync();
        return Ok(bottomGrids);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BottomGridById(int id)
    {
        var bottomGrid = await _bottomGridRepository.GetBottomGridAsync(id);
        return Ok(bottomGrid);
    }

    [HttpPost]
    public IActionResult CreateBottomGrid(CreateBottomGridDto bottomGridDto)
    {
        _bottomGridRepository.CreateBottomGrid(bottomGridDto);
        return Ok("Yeni Hizmet Başarılı Bir Şekilde Eklendi!");
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBottomGrid(int id)
    {
        _bottomGridRepository.DeleteBottomGrid(id);
        return Ok("Hizmet Başarılı Bir Şekilde Silindi!");

    }

    [HttpPut]
    public IActionResult UpdateBottomGrid(UpdateBottomGridDto bottomGridDto)
    {
        _bottomGridRepository.UpdateBottomGrid(bottomGridDto);
        return Ok("Hizmet Başarılı Bir Şekilde Güncellendi!");
    }
}
