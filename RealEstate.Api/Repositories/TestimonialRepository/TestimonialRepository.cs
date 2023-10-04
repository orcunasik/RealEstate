using Dapper;
using RealEstate.Api.Dtos.TestimonialDtos;
using RealEstate.Api.Models.DapperContext;

namespace RealEstate.Api.Repositories.TestimonialRepository;

public class TestimonialRepository : ITestimonialRepository
{
    private readonly BaseContext _context;

    public TestimonialRepository(BaseContext context)
    {
        _context = context;
    }

    public async void CreateTestimonial(CreateTestimonialDto testimonialDto)
    {
        string query = "Insert into Testimonials (NameSurname,Title,Comment,Status) values (@nameSurname,@title,@comment,@status)";
        var parameters = new DynamicParameters();
        parameters.Add("@nameSurname", testimonialDto.NameSurname);
        parameters.Add("@title", testimonialDto.Title);
        parameters.Add("@comment", testimonialDto.Comment);
        parameters.Add("@status", testimonialDto.Status);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async void DeleteTestimonial(int id)
    {
        string query = "Delete From Testimonials Where TestimonialId = @testimonialId";
        var parameters = new DynamicParameters();
        parameters.Add("@testimonialId", id);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<List<ResultTestimonialDto>> GetAllTestimonialAsync()
    {
        string query = "Select * From Testimonials";
        using (var connection = _context.CreateConnection())
        {
            var testimonials = await connection.QueryAsync<ResultTestimonialDto>(query);
            return testimonials.ToList();
        }
    }

    public async Task<GetByIdTestimonialDto> GetTestimonialAsync(int id)
    {
        string query = "Select * From Testimonials Where TestimonialId = @testimonialId";
        var parameters = new DynamicParameters();
        parameters.Add("@testimonialId", id);
        using (var connection = _context.CreateConnection())
        {
            dynamic testimonial = await connection.QueryFirstOrDefaultAsync<GetByIdTestimonialDto>(query, parameters);
            return testimonial;
        }
    }

    public async void UpdateTestimonial(UpdateTestimonialDto testimonialDto)
    {
        string query = "Update Testimonials Set NameSurname = @nameSurname,Title = @title,Comment =@comment, Status = @status Where TestimonialId = @testimonialId";
        var parameters = new DynamicParameters();
        parameters.Add("@testimonialId", testimonialDto.TestimonialId);
        parameters.Add("@nameSurname", testimonialDto.NameSurname);
        parameters.Add("@title", testimonialDto.Title);
        parameters.Add("@comment", testimonialDto.Comment);
        parameters.Add("@status", testimonialDto.Status);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
