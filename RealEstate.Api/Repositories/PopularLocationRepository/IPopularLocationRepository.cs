using RealEstate.Api.Dtos.PopularLocationDtos;

namespace RealEstate.Api.Repositories.PopularLocationRepository;

public interface IPopularLocationRepository
{
    Task<List<ResultPopularLocationDto>> GetAllPopularLocationsAsync();
    Task<GetByIdPopularLocationDto> GetPopularLocationAsync(int id);
    void CreatePopularLocation(CreatePopularLocationDto popularLocationDto);
    void UpdatePopularLocation(UpdatePopularLocationDto popularLocationDto);
    void DeletePopularLocation(int id);
}
