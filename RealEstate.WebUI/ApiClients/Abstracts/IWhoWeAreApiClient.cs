using RealEstate.WebUI.Dtos.WhoWeAreDetailDtos;

namespace RealEstate.WebUI.ApiClients.Abstracts;

public interface IWhoWeAreApiClient
{
    Task<List<ResultWhoWeAreDetailDto>> GetAllAsync();
    Task<UpdateWhoWeAreDetailDto> GetUpdateAsync(int id);
    Task<CreateWhoWeAreDetailDto> AddAsync(CreateWhoWeAreDetailDto weAreDetailDto);
    Task<bool> UpdateAsync(UpdateWhoWeAreDetailDto weAreDetailDto);
    Task<bool> DeleteAsync(int id);
}