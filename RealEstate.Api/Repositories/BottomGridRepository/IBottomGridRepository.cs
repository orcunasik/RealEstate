using RealEstate.Api.Dtos.BottomGridDtos;

namespace RealEstate.Api.Repositories.BottomGridRepository;

public interface IBottomGridRepository
{
    Task<List<ResultBottomGridDto>> GetAllBottomGridAsync();
    Task<GetByIdBottomGridDto> GetBottomGridAsync(int id);
    GetByIdBottomGridDto GetBottomGrid(int id);
    Task<CreateBottomGridDto> CreateBottomGridAsync(CreateBottomGridDto bottomGridDto);
    void UpdateBottomGrid(UpdateBottomGridDto bottomGridDto);
    void DeleteBottomGrid(GetByIdBottomGridDto bottomGridDto);
}
