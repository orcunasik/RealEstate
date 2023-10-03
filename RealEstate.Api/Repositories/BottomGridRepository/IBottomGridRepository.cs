using RealEstate.Api.Dtos.BottomGridDtos;

namespace RealEstate.Api.Repositories.BottomGridRepository;

public interface IBottomGridRepository
{
    Task<List<ResultBottomGridDto>> GetAllBottomGridAsync();
    Task<GetByIdBottomGridDto> GetBottomGridAsync(int id);
    void CreateBottomGrid(CreateBottomGridDto bottomGridDto);
    void UpdateBottomGrid(UpdateBottomGridDto bottomGridDto);
    void DeleteBottomGrid(int id);
}
