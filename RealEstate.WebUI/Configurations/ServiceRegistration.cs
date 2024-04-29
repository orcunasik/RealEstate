using Microsoft.AspNetCore.Authentication.JwtBearer;
using RealEstate.WebUI.ApiClients.Abstracts;
using RealEstate.WebUI.ApiClients.Concretes;

namespace RealEstate.WebUI.Configurations;

public static class ServiceRegistration
{
    public static void LoadMyServices(this IServiceCollection services)
    {
        services.AddHttpClient();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(JwtBearerDefaults.AuthenticationScheme, opt =>
        {
            opt.LoginPath = "/Login/Index/";
            opt.LogoutPath = "/Login/LogOut/";
            opt.AccessDeniedPath = "/Pages/AccessDenied/";
            opt.Cookie.HttpOnly = true;
            opt.Cookie.SameSite = SameSiteMode.Strict;
            opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
            opt.Cookie.Name = "RealEstateJwt";
        });

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
        services.AddTransient<IContactApiClient, ContactApiClient>();
        services.AddTransient<IToDoListApiClient, ToDoListApiClient>();
    }
}