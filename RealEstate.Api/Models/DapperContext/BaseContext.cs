using Microsoft.Data.SqlClient;
using System.Data;

namespace RealEstate.Api.Models.DapperContext;

public class BaseContext
{
    private readonly IConfiguration _configuraiton;
    private readonly string _connectionString;

    public BaseContext(IConfiguration configuraiton)
    {
        _configuraiton = configuraiton;
        _connectionString = _configuraiton.GetConnectionString("connection");
    }
    public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
}
