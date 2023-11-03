using RealEstate.Api.Models.DapperContext;
using RealEstate.Api.Repositories.BottomGridRepository;
using RealEstate.Api.Repositories.CategoryRepository;
using RealEstate.Api.Repositories.EmployeeRepository;
using RealEstate.Api.Repositories.PopularLocationRepository;
using RealEstate.Api.Repositories.ProductRepository;
using RealEstate.Api.Repositories.ServiceRepository;
using RealEstate.Api.Repositories.StatisticsRepository;
using RealEstate.Api.Repositories.TestimonialRepository;
using RealEstate.Api.Repositories.WhoWeAreDetailRepository;

namespace RealEstate.Api.Extensions;

public static class ServiceRegistration
{
    public static void LoadMyRepositories(this IServiceCollection services)
    {
        services.AddTransient<BaseContext>();
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<IWhoWeAreDetailRepository, WhoWeAreDetailRepository>();
        services.AddTransient<IServiceRepository, ServiceRepository>();
        services.AddTransient<IStatisticsRepository, StatisticsRepository>();
        services.AddTransient<IBottomGridRepository, BottomGridRepository>();
        services.AddTransient<IPopularLocationRepository, PopularLocationRepository>();
        services.AddTransient<ITestimonialRepository, TestimonialRepository>();
        services.AddTransient<IEmployeeRepository, EmployeeRepository>();
    }
}
