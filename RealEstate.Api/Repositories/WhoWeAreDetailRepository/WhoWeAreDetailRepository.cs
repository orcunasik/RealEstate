using Dapper;
using RealEstate.Api.Dtos.WhoWeAreDetailDtos;
using RealEstate.Api.Models.DapperContext;
using System.Data;

namespace RealEstate.Api.Repositories.WhoWeAreDetailRepository;

public class WhoWeAreDetailRepository : IWhoWeAreDetailRepository
{
    private readonly BaseContext _context;

    public WhoWeAreDetailRepository(BaseContext context)
    {
        _context = context;
    }

    public async Task<CreateWhoWeAreDetailDto> CreateWhoWeAreDetailAsync(CreateWhoWeAreDetailDto whoWeAreDetailDto)
    {
        string insertQuery = "Insert into WhoWeAreDetails (Title,Subtitle,Description1,Description2) values (@title,@subtitle,@description1,@description2);SELECT SCOPE_IDENTITY()";
        DynamicParameters parameters = new();
        parameters.Add("@title", whoWeAreDetailDto.Title);
        parameters.Add("@subtitle", whoWeAreDetailDto.Subtitle);
        parameters.Add("@description1", whoWeAreDetailDto.Description1);
        parameters.Add("@description2", whoWeAreDetailDto.Description2);
        using (IDbConnection connection = _context.CreateConnection())
        {
            int whoWeAreDetailId = await connection.QuerySingleAsync<int>(insertQuery, parameters);
            string selectQuery = "Select * From WhoWeAreDetails Where WhoWeAreDetailId = @whoWeAreDetailId";
            CreateWhoWeAreDetailDto whoWeAreDetail = await connection.QuerySingleOrDefaultAsync<CreateWhoWeAreDetailDto>(selectQuery, new { whoWeAreDetailId });
            return whoWeAreDetail;
        }
    }

    public async void DeleteWhoWeAreDetail(GetByIdWhoWeAreDetailDto whoWeAreDetailDto)
    {
        string deleteQuery = "Delete From WhoWeAreDetails Where WhoWeAreDetailId = @whoWeAreDetailId";
        DynamicParameters parameter = new();
        parameter.Add("@whoWeAreDetailId", whoWeAreDetailDto.WhoWeAreDetailId);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(deleteQuery, parameter);
        }
    }

    public async Task<List<ResultWhoWeAreDetailDto>> GetAllWhoWeAreDetailAsync()
    {
        string listQuery = "Select * From WhoWeAreDetails";
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<ResultWhoWeAreDetailDto> whoWeAreDetails = await connection.QueryAsync<ResultWhoWeAreDetailDto>(listQuery);
            return whoWeAreDetails.ToList();
        }
    }

    public GetByIdWhoWeAreDetailDto GetWhoWeAreDetail(int id)
    {
        string getByIdQuery = "Select * From WhoWeAreDetails Where WhoWeAreDetailId = @whoWeAreDetailId";
        DynamicParameters parameter = new();
        parameter.Add("@whoWeAreDetailId", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            dynamic whoWeAreDetail = connection.QueryFirstOrDefault<GetByIdWhoWeAreDetailDto>(getByIdQuery, parameter);
            return whoWeAreDetail;
        }
    }

    public async Task<GetByIdWhoWeAreDetailDto> GetWhoWeAreDetailAsync(int id)
    {
        string getByIdQuery = "Select * From WhoWeAreDetails Where WhoWeAreDetailId = @whoWeAreDetailId";
        DynamicParameters parameter = new();
        parameter.Add("@whoWeAreDetailId", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            dynamic whoWeAreDetail = await connection.QueryFirstOrDefaultAsync<GetByIdWhoWeAreDetailDto>(getByIdQuery, parameter);
            return whoWeAreDetail;
        }
    }

    public async void UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto whoWeAreDetailDto)
    {
        string updateQuery = "Update WhoWeAreDetails Set Title = @title, Subtitle = @subtitle, Description1 = @description1, Description2 = @description2 Where WhoWeAreDetailId = @whoWeAreDetailId";
        DynamicParameters parameters = new();
        parameters.Add("@whoWeAreDetailId", whoWeAreDetailDto.WhoWeAreDetailId);
        parameters.Add("@title", whoWeAreDetailDto.Title);
        parameters.Add("@subtitle", whoWeAreDetailDto.Subtitle);
        parameters.Add("@description1", whoWeAreDetailDto.Description1);
        parameters.Add("@description2", whoWeAreDetailDto.Description2);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(updateQuery, parameters);
        }
    }
}
