using RealEstate.WebUI.Dtos.ServiceDtos;

namespace RealEstate.WebUI.ApiClients.Abstracts;

public interface IServiceApiClient
{
    Task<List<ResultServiceDto>> GetAllAsync();
    Task<UpdateServiceDto> GetUpdateAsync(int id);
    Task<CreateServiceDto> AddAsync(CreateServiceDto serviceDto);
    Task<bool> UpdateAsync(UpdateServiceDto serviceDto);
    Task<bool> DeleteAsync(int id);
}
