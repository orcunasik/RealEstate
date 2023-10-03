using Microsoft.AspNetCore.Mvc;
using RealEstate.Api.Dtos.ServiceDtos;
using RealEstate.Api.Repositories.ServiceRepository;

namespace RealEstate.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServicesController : ControllerBase
{
    private readonly IServiceRepository _serviceRepository;

    public ServicesController(IServiceRepository serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }

    [HttpGet]
    public async Task<IActionResult> ServiceList()
    {
        var services = await _serviceRepository.GetAllServiceAsync();
        return Ok(services);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ServiceById(int id)
    {
        var service = await _serviceRepository.GetServiceAsync(id);
        return Ok(service);
    }

    [HttpPost]
    public IActionResult CreateService(CreateServiceDto serviceDto)
    {
        _serviceRepository.CreateService(serviceDto);
        return Ok("Yeni Hizmet Başarılı Bir Şekilde Eklendi!");
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteService(int id)
    {
        _serviceRepository.DeleteService(id);
        return Ok("Hizmet Başarılı Bir Şekilde Silindi!");

    }

    [HttpPut]
    public IActionResult UpdateService(UpdateServiceDto serviceDto)
    {
        _serviceRepository.UpdateService(serviceDto);
        return Ok("Hizmet Başarılı Bir Şekilde Güncellendi!");
    }
}
