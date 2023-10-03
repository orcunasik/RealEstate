using RealEstate.Api.Dtos.ServiceDtos;

namespace RealEstate.Api.Repositories.ServiceRepository;

public interface IServiceRepository
{
    Task<List<ResultServiceDto>> GetAllServiceAsync();
    Task<GetByIdServiceDto> GetServiceAsync(int id);
    void CreateService(CreateServiceDto serviceDto);
    void UpdateService(UpdateServiceDto serviceDto);
    void DeleteService(int id);
}
