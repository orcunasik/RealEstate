using RealEstate.WebUI.ApiClients.Abstracts;
using RealEstate.WebUI.ApiClients.Concretes;

namespace RealEstate.WebUI.Configurations;

public static class ServiceRegistration
{
    public static void LoadMyServices(this IServiceCollection services)
    {
        services.AddHttpClient();

        services.AddTransient<IDomainService, DomainService>();

        services.AddTransient<ICategoryApiClient, CategoryApiClient>();
        services.AddTransient<IProductApiClient, ProductApiClient>();
        services.AddTransient<IEmployeeApiClient, EmployeeApiClient>();
        services.AddTransient<IServiceApiClient, ServiceApiClient>();
        services.AddTransient<IWhoWeAreApiClient, WhoWeAreApiClient>();
        services.AddTransient<IStatisticsApiClient, StatisticsApiClient>();
        services.AddTransient<IBottomGridApiClient, BottomGridApiClient>();
        services.AddTransient<IPopularLocationApiClient, PopularLocationApiClient>();
        services.AddTransient<ITestimonialApiClient, TestimonialApiClient>();
    }
}