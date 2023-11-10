using Dapper;
using RealEstate.Api.Dtos.BottomGridDtos;
using RealEstate.Api.Models.DapperContext;
using System.Data;

namespace RealEstate.Api.Repositories.BottomGridRepository;

public class BottomGridRepository : IBottomGridRepository
{
    private readonly BaseContext _context;

    public BottomGridRepository(BaseContext context)
    {
        _context = context;
    }

    public async Task<CreateBottomGridDto> CreateBottomGridAsync(CreateBottomGridDto bottomGridDto)
    {
        string insertQuery = "Insert into BottomGrids (Title,Icon,Description) values (@title,@icon,@description);SELECT SCOPE_IDENTITY()";
        DynamicParameters parameters = new();
        parameters.Add("@title", bottomGridDto.Title);
        parameters.Add("@icon", bottomGridDto.Icon);
        parameters.Add("@description", bottomGridDto.Description);
        using (IDbConnection connection = _context.CreateConnection())
        {
            int bottomGridId = await connection.QuerySingleAsync<int>(insertQuery, parameters);
            string selectQuery = "Select * From BottomGrids Where BottomGridId = @bottomGridId";
            CreateBottomGridDto bottomGrid = await connection.QuerySingleOrDefaultAsync<CreateBottomGridDto>(selectQuery, new { bottomGridId });
            return bottomGrid;
        }
    }

    public async void DeleteBottomGrid(GetByIdBottomGridDto bottomGridDto)
    {
        string deleteQuery = "Delete From BottomGrids Where BottomGridId = @bottomGridId";
        DynamicParameters parameter = new();
        parameter.Add("@bottomGridId", bottomGridDto.BottomGridId);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(deleteQuery, parameter);
        }
    }

    public async Task<List<ResultBottomGridDto>> GetAllBottomGridAsync()
    {
        string listQuery = "Select * From BottomGrids";
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<ResultBottomGridDto> bottomGrids = await connection.QueryAsync<ResultBottomGridDto>(listQuery);
            return bottomGrids.ToList();
        }
    }

    public GetByIdBottomGridDto GetBottomGrid(int id)
    {
        string getByIdQuery = "Select * From BottomGrids Where BottomGridId = @bottomGridId";
        DynamicParameters parameter = new();
        parameter.Add("@bottomGridId", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            dynamic bottomGrid = connection.QueryFirstOrDefaultAsync<GetByIdBottomGridDto>(getByIdQuery,parameter);
            return bottomGrid;
        }
    }

    public async Task<GetByIdBottomGridDto> GetBottomGridAsync(int id)
    {
        string getByIdQuery = "Select * From BottomGrids Where BottomGridId = @bottomGridId";
        DynamicParameters parameter = new();
        parameter.Add("@bottomGridId", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            dynamic bottomGrid = await connection.QueryFirstOrDefaultAsync<GetByIdBottomGridDto>(getByIdQuery, parameter);
            return bottomGrid;
        }
    }

    public async void UpdateBottomGrid(UpdateBottomGridDto bottomGridDto)
    {
        string updateQuery = "Update BottomGrids Set Title = @title, Icon = @icon,Description = @description Where BottomGridId = @bottomGridId";
        DynamicParameters parameters = new();
        parameters.Add("@bottomGridId", bottomGridDto.BottomGridId);
        parameters.Add("@title", bottomGridDto.Title);
        parameters.Add("@icon", bottomGridDto.Icon);
        parameters.Add("@description", bottomGridDto.Description);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(updateQuery, parameters);
        }
    }
}
