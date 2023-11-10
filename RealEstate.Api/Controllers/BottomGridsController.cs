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
        List<ResultBottomGridDto> bottomGrids = await _bottomGridRepository.GetAllBottomGridAsync();
        return Ok(bottomGrids);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BottomGridById(int id)
    {
        GetByIdBottomGridDto bottomGrid = await _bottomGridRepository.GetBottomGridAsync(id);
        return Ok(bottomGrid);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBottomGrid(CreateBottomGridDto bottomGridDto)
    {
        CreateBottomGridDto bottomGrid = await _bottomGridRepository.CreateBottomGridAsync(bottomGridDto);
        return Ok(bottomGrid);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBottomGrid(int id)
    {
        GetByIdBottomGridDto bottomGridDto = _bottomGridRepository.GetBottomGrid(id);
        _bottomGridRepository.DeleteBottomGrid(bottomGridDto);
        return Ok("Hizmet Başarılı Bir Şekilde Silindi!");

    }

    [HttpPut]
    public IActionResult UpdateBottomGrid(UpdateBottomGridDto bottomGridDto)
    {
        _bottomGridRepository.UpdateBottomGrid(bottomGridDto);
        return Ok("Hizmet Başarılı Bir Şekilde Güncellendi!");
    }
}
