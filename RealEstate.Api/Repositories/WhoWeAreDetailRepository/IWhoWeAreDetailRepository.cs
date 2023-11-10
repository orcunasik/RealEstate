using RealEstate.Api.Dtos.WhoWeAreDetailDtos;

namespace RealEstate.Api.Repositories.WhoWeAreDetailRepository;
public interface IWhoWeAreDetailRepository
{
    Task<List<ResultWhoWeAreDetailDto>> GetAllWhoWeAreDetailAsync();
    Task<GetByIdWhoWeAreDetailDto> GetWhoWeAreDetailAsync(int id);
    GetByIdWhoWeAreDetailDto GetWhoWeAreDetail(int id);
    Task<CreateWhoWeAreDetailDto> CreateWhoWeAreDetailAsync(CreateWhoWeAreDetailDto whoWeAreDetailDto);
    void DeleteWhoWeAreDetail(GetByIdWhoWeAreDetailDto whoWeAreDetailDto);
    void UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto whoWeAreDetailDto);
}
