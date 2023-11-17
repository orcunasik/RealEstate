using RealEstate.WebUI.Dtos.PopularLocationDtos;

namespace RealEstate.WebUI.ApiClients.Abstracts;

public interface IPopularLocationApiClient
{
    Task<List<ResultPopularLocationDto>> GetAllAsync();
    Task<UpdatePopularLocationDto> GetUpdateAsync(int id);
    Task<CreatePopularLocationDto> AddAsync(CreatePopularLocationDto popularLocationDto);
    Task<bool> UpdateAsync(UpdatePopularLocationDto popularLocationDto);
    Task<bool> DeleteAsync(int id);
}
