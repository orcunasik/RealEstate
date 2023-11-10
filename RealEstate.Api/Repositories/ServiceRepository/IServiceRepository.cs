using RealEstate.Api.Dtos.ServiceDtos;

namespace RealEstate.Api.Repositories.ServiceRepository;

public interface IServiceRepository
{
    Task<List<ResultServiceDto>> GetAllServiceAsync();
    Task<GetByIdServiceDto> GetServiceAsync(int id);
    GetByIdServiceDto GetService(int id);
    Task<CreateServiceDto> CreateServiceAsync(CreateServiceDto serviceDto);
    void UpdateService(UpdateServiceDto serviceDto);
    void DeleteService(GetByIdServiceDto serviceDto);
}
