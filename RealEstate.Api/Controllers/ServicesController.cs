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
        List<ResultServiceDto> services = await _serviceRepository.GetAllServiceAsync();
        return Ok(services);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ServiceById(int id)
    {
        GetByIdServiceDto service = await _serviceRepository.GetServiceAsync(id);
        return Ok(service);
    }

    [HttpPost]
    public async Task<IActionResult> CreateService(CreateServiceDto serviceDto)
    {
        CreateServiceDto service = await _serviceRepository.CreateServiceAsync(serviceDto);
        return Ok(service);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteService(int id)
    {
        GetByIdServiceDto service = _serviceRepository.GetService(id);
        _serviceRepository.DeleteService(service);
        return Ok("Hizmet Başarılı Bir Şekilde Silindi!");

    }

    [HttpPut]
    public IActionResult UpdateService(UpdateServiceDto serviceDto)
    {
        _serviceRepository.UpdateService(serviceDto);
        return Ok("Hizmet Başarılı Bir Şekilde Güncellendi!");
    }
}
