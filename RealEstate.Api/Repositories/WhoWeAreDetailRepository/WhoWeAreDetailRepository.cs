using Dapper;
using RealEstate.Api.Dtos.CategoryDtos;
using RealEstate.Api.Dtos.WhoWeAreDetailDtos;
using RealEstate.Api.Models.DapperContext;

namespace RealEstate.Api.Repositories.WhoWeAreDetailRepository;

public class WhoWeAreDetailRepository : IWhoWeAreDetailRepository
{
    private readonly BaseContext _context;

    public WhoWeAreDetailRepository(BaseContext context)
    {
        _context = context;
    }

    public async void CreateWhoWeAreDetail(CreateWhoWeAreDetailDto whoWeAreDetailDto)
    {
        string query = "Insert into WhoWeAreDetails (Title,Subtitle,Description1,Description2) values (@title,@subtitle,@description1,@description2)";
        var parameters = new DynamicParameters();
        parameters.Add("@title", whoWeAreDetailDto.Title);
        parameters.Add("@subtitle", whoWeAreDetailDto.Subtitle);
        parameters.Add("@description1", whoWeAreDetailDto.Description1);
        parameters.Add("@description2", whoWeAreDetailDto.Description2);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async void DeleteWhoWeAreDetail(int id)
    {
        string query = "Delete From WhoWeAreDetails Where WhoWeAreDetailId = @whoWeAreDetailId";
        var parameters = new DynamicParameters();
        parameters.Add("@whoWeAreDetailId", id);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<List<ResultWhoWeAreDetailDto>> GetAllWhoWeAreDetailAsync()
    {
        string query = "Select * From WhoWeAreDetails";
        using (var connection = _context.CreateConnection())
        {
            var whoWeAreDetails = await connection.QueryAsync<ResultWhoWeAreDetailDto>(query);
            return whoWeAreDetails.ToList();
        }
    }

    public async Task<GetByIdWhoWeAreDetailDto> GetWhoWeAreDetailAsync(int id)
    {
        string query = "Select * From WhoWeAreDetails Where WhoWeAreDetailId = @whoWeAreDetailId";
        var parameters = new DynamicParameters();
        parameters.Add("@whoWeAreDetailId", id);
        using (var connection = _context.CreateConnection())
        {
            dynamic whoWeAreDetail = await connection.QueryFirstOrDefaultAsync<GetByIdWhoWeAreDetailDto>(query, parameters);
            return whoWeAreDetail;
        }
    }

    public async void UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto whoWeAreDetailDto)
    {
        string query = "Update WhoWeAreDetails Set Title = @title, Subtitle = @subtitle, Description1 = @description1, Description2 = @description2 Where WhoWeAreDetailId = @whoWeAreDetailId";
        var parameters = new DynamicParameters();
        parameters.Add("@whoWeAreDetailId", whoWeAreDetailDto.WhoWeAreDetailId);
        parameters.Add("@title", whoWeAreDetailDto.Title);
        parameters.Add("@subtitle", whoWeAreDetailDto.Subtitle);
        parameters.Add("@description1", whoWeAreDetailDto.Description1);
        parameters.Add("@description2", whoWeAreDetailDto.Description2);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
