namespace RealEstate.WebUI.Configurations;

public class DomainService : IDomainService
{
    private readonly IConfiguration _configuration;

    public DomainService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string Domain()
    {
       return _configuration.GetSection("Host").Value;
    }
}
