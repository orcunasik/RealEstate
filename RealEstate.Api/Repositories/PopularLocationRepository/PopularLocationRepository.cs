using Dapper;
using RealEstate.Api.Dtos.PopularLocationDtos;
using RealEstate.Api.Models.DapperContext;

namespace RealEstate.Api.Repositories.PopularLocationRepository;

public class PopularLocationRepository : IPopularLocationRepository
{
    private readonly BaseContext _context;

    public PopularLocationRepository(BaseContext context)
    {
        _context = context;
    }

    public async void CreatePopularLocation(CreatePopularLocationDto popularLocationDto)
    {
        string query = "Insert into PopularLocations (CityName,ImageUrl) values (@cityName,@imageUrl)";
        var parameters = new DynamicParameters();
        parameters.Add("@cityName", popularLocationDto.CityName);
        parameters.Add("@imageUrl", popularLocationDto.ImageUrl);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async void DeletePopularLocation(int id)
    {
        string query = "Delete From PopularLocations Where LocationId = @locationId";
        var parameters = new DynamicParameters();
        parameters.Add("@locationId", id);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<List<ResultPopularLocationDto>> GetAllPopularLocationsAsync()
    {
        string query = "Select * From PopularLocations";
        using (var connection = _context.CreateConnection())
        {
            var locations = await connection.QueryAsync<ResultPopularLocationDto>(query);
            return locations.ToList();
        };
    }

    public async Task<GetByIdPopularLocationDto> GetPopularLocationAsync(int id)
    {
        string query = "Select * From PopularLocations Where LocationId = @locationId";
        var parameters = new DynamicParameters();
        parameters.Add("@locationId", id);
        using (var connection = _context.CreateConnection())
        {
            dynamic location = await connection.QueryFirstOrDefaultAsync<GetByIdPopularLocationDto>(query, parameters);
            return location;
        }
    }

    public async void UpdatePopularLocation(UpdatePopularLocationDto popularLocationDto)
    {
        string query = "Update PopularLocations Set CityName = @cityName, ImageUrl = @imageUrl Where LocationId = @locationId";
        var parameters = new DynamicParameters();
        parameters.Add("@locationId", popularLocationDto.LocationId);
        parameters.Add("@cityName", popularLocationDto.CityName);
        parameters.Add("@imageUrl", popularLocationDto.ImageUrl);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
