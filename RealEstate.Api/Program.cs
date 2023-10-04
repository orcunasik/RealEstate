using RealEstate.Api.Models.DapperContext;
using RealEstate.Api.Repositories.BottomGridRepository;
using RealEstate.Api.Repositories.CategoryRepository;
using RealEstate.Api.Repositories.PopularLocationRepository;
using RealEstate.Api.Repositories.ProductRepository;
using RealEstate.Api.Repositories.ServiceRepository;
using RealEstate.Api.Repositories.TestimonialRepository;
using RealEstate.Api.Repositories.WhoWeAreDetailRepository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<BaseContext>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IWhoWeAreDetailRepository, WhoWeAreDetailRepository>();
builder.Services.AddTransient<IServiceRepository, ServiceRepository>();
builder.Services.AddTransient<IBottomGridRepository, BottomGridRepository>();
builder.Services.AddTransient<IPopularLocationRepository, PopularLocationRepository>();
builder.Services.AddTransient<ITestimonialRepository, TestimonialRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
