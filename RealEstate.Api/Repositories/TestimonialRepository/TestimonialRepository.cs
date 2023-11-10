using Dapper;
using RealEstate.Api.Dtos.TestimonialDtos;
using RealEstate.Api.Models.DapperContext;
using System.Data;

namespace RealEstate.Api.Repositories.TestimonialRepository;

public class TestimonialRepository : ITestimonialRepository
{
    private readonly BaseContext _context;

    public TestimonialRepository(BaseContext context)
    {
        _context = context;
    }

    public async Task<CreateTestimonialDto> CreateTestimonialAsync(CreateTestimonialDto testimonialDto)
    {
        string insertQuery = "Insert into Testimonials (NameSurname,Title,Comment,Status) values (@nameSurname,@title,@comment,@status);SELECT SCOPE_IDENTITY()";
        DynamicParameters parameters = new();
        parameters.Add("@nameSurname", testimonialDto.NameSurname);
        parameters.Add("@title", testimonialDto.Title);
        parameters.Add("@comment", testimonialDto.Comment);
        parameters.Add("@status", testimonialDto.Status);
        using (IDbConnection connection = _context.CreateConnection())
        {
            int testimonialId = await connection.QuerySingleAsync<int>(insertQuery, parameters);
            string selectQuery = "Select * From Testimonials Where TestimonialId = @testimonialId";
            CreateTestimonialDto testimonial = await connection.QuerySingleOrDefaultAsync<CreateTestimonialDto>(selectQuery, new { testimonialId });
            return testimonial;
        }
    }

    public async void DeleteTestimonial(GetByIdTestimonialDto testimonialDto)
    {
        string deleteQuery = "Delete From Testimonials Where TestimonialId = @testimonialId";
        DynamicParameters parameter = new();
        parameter.Add("@testimonialId", testimonialDto.TestimonialId);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(deleteQuery, parameter);
        }
    }

    public async Task<List<ResultTestimonialDto>> GetAllTestimonialAsync()
    {
        string listQuery = "Select * From Testimonials";
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<ResultTestimonialDto> testimonials = await connection.QueryAsync<ResultTestimonialDto>(listQuery);
            return testimonials.ToList();
        }
    }

    public GetByIdTestimonialDto GetTestimonial(int id)
    {
        string getByIdQuery = "Select * From Testimonials Where TestimonialId = @testimonialId";
        DynamicParameters parameter = new();
        parameter.Add("@testimonialId", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            dynamic testimonial = connection.QueryFirstOrDefault<GetByIdTestimonialDto>(getByIdQuery, parameter);
            return testimonial;
        }
    }

    public async Task<GetByIdTestimonialDto> GetTestimonialAsync(int id)
    {
        string getByIdQuery = "Select * From Testimonials Where TestimonialId = @testimonialId";
        DynamicParameters parameter = new();
        parameter.Add("@testimonialId", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            dynamic testimonial = await connection.QueryFirstOrDefaultAsync<GetByIdTestimonialDto>(getByIdQuery, parameter);
            return testimonial;
        }
    }

    public async void UpdateTestimonial(UpdateTestimonialDto testimonialDto)
    {
        string updateQuery = "Update Testimonials Set NameSurname = @nameSurname,Title = @title,Comment =@comment, Status = @status Where TestimonialId = @testimonialId";
        DynamicParameters parameters = new();
        parameters.Add("@testimonialId", testimonialDto.TestimonialId);
        parameters.Add("@nameSurname", testimonialDto.NameSurname);
        parameters.Add("@title", testimonialDto.Title);
        parameters.Add("@comment", testimonialDto.Comment);
        parameters.Add("@status", testimonialDto.Status);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(updateQuery, parameters);
        }
    }
}
