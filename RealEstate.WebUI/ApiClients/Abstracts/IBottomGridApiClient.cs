using RealEstate.WebUI.Dtos.BottomGridDtos;

namespace RealEstate.WebUI.ApiClients.Abstracts;

public interface IBottomGridApiClient
{
    Task<List<ResultBottomGridDto>> GetAllAsync();
    Task<UpdateBottomGridDto> GetUpdateAsync(int id);
    Task<CreateBottomGridDto> AddAsync(CreateBottomGridDto bottomGridDto);
    Task<bool> UpdateAsync(UpdateBottomGridDto bottomGridDto);
    Task<bool> DeleteAsync(int id);
}
