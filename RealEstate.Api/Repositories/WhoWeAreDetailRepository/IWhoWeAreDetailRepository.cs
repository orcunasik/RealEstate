using RealEstate.Api.Dtos.WhoWeAreDetailDtos;

namespace RealEstate.Api.Repositories.WhoWeAreDetailRepository;
public interface IWhoWeAreDetailRepository
{
    Task<List<ResultWhoWeAreDetailDto>> GetAllWhoWeAreDetailAsync();
    Task<GetByIdWhoWeAreDetailDto> GetWhoWeAreDetailAsync(int id);
    void CreateWhoWeAreDetail(CreateWhoWeAreDetailDto whoWeAreDetailDto);
    void DeleteWhoWeAreDetail(int id);
    void UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto whoWeAreDetailDto);
}
