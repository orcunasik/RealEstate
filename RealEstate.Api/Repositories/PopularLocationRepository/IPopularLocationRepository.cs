using RealEstate.Api.Dtos.PopularLocationDtos;

namespace RealEstate.Api.Repositories.PopularLocationRepository;

public interface IPopularLocationRepository
{
    Task<List<ResultPopularLocationDto>> GetAllPopularLocationsAsync();
    Task<GetByIdPopularLocationDto> GetPopularLocationAsync(int id);
    GetByIdPopularLocationDto GetPopularLocation(int id);
    Task<CreatePopularLocationDto> CreatePopularLocationAsync(CreatePopularLocationDto popularLocationDto);
    void UpdatePopularLocation(UpdatePopularLocationDto popularLocationDto);
    void DeletePopularLocation(GetByIdPopularLocationDto popularLocationDto);
}
