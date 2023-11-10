using Dapper;
using RealEstate.Api.Dtos.PopularLocationDtos;
using RealEstate.Api.Models.DapperContext;
using System.Data;

namespace RealEstate.Api.Repositories.PopularLocationRepository;

public class PopularLocationRepository : IPopularLocationRepository
{
    private readonly BaseContext _context;

    public PopularLocationRepository(BaseContext context)
    {
        _context = context;
    }

    public async Task<CreatePopularLocationDto> CreatePopularLocationAsync(CreatePopularLocationDto popularLocationDto)
    {
        string insertQuery = "Insert into PopularLocations (CityName,ImageUrl) values (@cityName,@imageUrl);SELECT SCOPE_IDENTITY()";
        DynamicParameters parameters = new();
        parameters.Add("@cityName", popularLocationDto.CityName);
        parameters.Add("@imageUrl", popularLocationDto.ImageUrl);
        using (IDbConnection connection = _context.CreateConnection())
        {
            int locationId = await connection.QuerySingleAsync<int>(insertQuery, parameters);
            string selectQuery = "Select * From PopularLocations Where LocationId = @locationId";
            CreatePopularLocationDto popularLocation = await connection.QuerySingleOrDefaultAsync<CreatePopularLocationDto>(selectQuery, new { locationId });
            return popularLocation;
        }
    }

    public async void DeletePopularLocation(GetByIdPopularLocationDto popularLocationDto)
    {
        string deleteQuery = "Delete From PopularLocations Where LocationId = @locationId";
        DynamicParameters parameter = new();
        parameter.Add("@locationId", popularLocationDto.LocationId);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(deleteQuery, parameter);
        }
    }

    public async Task<List<ResultPopularLocationDto>> GetAllPopularLocationsAsync()
    {
        string listQuery = "Select * From PopularLocations";
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<ResultPopularLocationDto> locations = await connection.QueryAsync<ResultPopularLocationDto>(listQuery);
            return locations.ToList();
        };
    }

    public GetByIdPopularLocationDto GetPopularLocation(int id)
    {
        string getByIdQuery = "Select * From PopularLocations Where LocationId = @locationId";
        DynamicParameters parameter = new();
        parameter.Add("@locationId", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            dynamic location = connection.QueryFirstOrDefault<GetByIdPopularLocationDto>(getByIdQuery, parameter);
            return location;
        }
    }

    public async Task<GetByIdPopularLocationDto> GetPopularLocationAsync(int id)
    {
        string getByIdQuery = "Select * From PopularLocations Where LocationId = @locationId";
        DynamicParameters parameter = new();
        parameter.Add("@locationId", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            dynamic location = await connection.QueryFirstOrDefaultAsync<GetByIdPopularLocationDto>(getByIdQuery, parameter);
            return location;
        }
    }

    public async void UpdatePopularLocation(UpdatePopularLocationDto popularLocationDto)
    {
        string updateQuery = "Update PopularLocations Set CityName = @cityName, ImageUrl = @imageUrl Where LocationId = @locationId";
        DynamicParameters parameters = new();
        parameters.Add("@locationId", popularLocationDto.LocationId);
        parameters.Add("@cityName", popularLocationDto.CityName);
        parameters.Add("@imageUrl", popularLocationDto.ImageUrl);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(updateQuery, parameters);
        }
    }
}
