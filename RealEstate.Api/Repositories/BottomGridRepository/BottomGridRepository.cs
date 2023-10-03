using Dapper;
using RealEstate.Api.Dtos.BottomGridDtos;
using RealEstate.Api.Models.DapperContext;

namespace RealEstate.Api.Repositories.BottomGridRepository;

public class BottomGridRepository : IBottomGridRepository
{
    private readonly BaseContext _context;

    public BottomGridRepository(BaseContext context)
    {
        _context = context;
    }

    public async void CreateBottomGrid(CreateBottomGridDto bottomGridDto)
    {
        string query = "Insert into BottomGrids (Title,Icon,Description) values (@title,@icon,@description)";
        var parameters = new DynamicParameters();
        parameters.Add("@title", bottomGridDto.Title);
        parameters.Add("@icon", bottomGridDto.Icon);
        parameters.Add("@description", bottomGridDto.Description);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async void DeleteBottomGrid(int id)
    {
        string query = "Delete From BottomGrids Where BottomGridId = @bottomGridId";
        var parameters = new DynamicParameters();
        parameters.Add("@bottomGridId", id);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<List<ResultBottomGridDto>> GetAllBottomGridAsync()
    {
        string query = "Select * From BottomGrids";
        using (var connection = _context.CreateConnection())
        {
            var bottomGrids = await connection.QueryAsync<ResultBottomGridDto>(query);
            return bottomGrids.ToList();
        }
    }

    public async Task<GetByIdBottomGridDto> GetBottomGridAsync(int id)
    {
        string query = "Select * From BottomGrids Where BottomGridId = @bottomGridId";
        var parameters = new DynamicParameters();
        parameters.Add("@bottomGridId", id);
        using (var connection = _context.CreateConnection())
        {
            dynamic bottomGrid = await connection.QueryFirstOrDefaultAsync<GetByIdBottomGridDto>(query, parameters);
            return bottomGrid;
        }
    }

    public async void UpdateBottomGrid(UpdateBottomGridDto bottomGridDto)
    {
        string query = "Update BottomGrids Set Title = @title, Icon = @icon,Description = @description Where BottomGridId = @bottomGridId";
        var parameters = new DynamicParameters();
        parameters.Add("@bottomGridId", bottomGridDto.BottomGridId);
        parameters.Add("@title", bottomGridDto.Title);
        parameters.Add("@icon", bottomGridDto.Icon);
        parameters.Add("@description", bottomGridDto.Description);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
