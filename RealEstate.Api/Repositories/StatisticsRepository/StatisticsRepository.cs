using Dapper;
using RealEstate.Api.Dtos.CategoryDtos;
using RealEstate.Api.Models.DapperContext;

namespace RealEstate.Api.Repositories.StatisticsRepository;

public class StatisticsRepository : IStatisticsRepository
{
    private readonly BaseContext _context;

    public StatisticsRepository(BaseContext context)
    {
        _context = context;
    }
    public int ActiveCategoryCount()
    {
        string query = "Select Count(*) From Categories Where Status = 1";
        using (var connection = _context.CreateConnection())
        {
            int activeCategoryCount = connection.QueryFirstOrDefault<int>(query);
            return activeCategoryCount;
        }
    }

    public int ActiveEmployeeCount()
    {
        string query = "Select Count(*) From Employees Where Status = 1";
        using (var connection = _context.CreateConnection())
        {
            int activeEmployeeCount = connection.QueryFirstOrDefault<int>(query);
            return activeEmployeeCount;
        }
    }

    public int ApartmentCount()
    {
        string query = "Select Count(*) From Products Where CategoryId = 3";
        using (var connection = _context.CreateConnection())
        {
            int apartmentCount = connection.QueryFirstOrDefault<int>(query);
            return apartmentCount;
        }
    }

    public decimal AvgProductPriceByRent()
    {
        string query = "SELECT AVG(Price) From Products WHERE Type = 'Kiralık' ";
        using (var connection = _context.CreateConnection())
        {
            decimal avgProductPriceByRent = connection.QueryFirstOrDefault<decimal>(query);
            return avgProductPriceByRent;
        }
    }

    public decimal AvgProductPriceBySale()
    {
        string query = "SELECT AVG(Price) From Products WHERE Type = 'Satılık' ";
        using (var connection = _context.CreateConnection())
        {
            decimal avgProductPriceBySale = connection.QueryFirstOrDefault<decimal>(query);
            return avgProductPriceBySale;
        }
    }

    public int AvgRoomCount()
    {
        string query = "SELECT AVG(RoomCount) From ProductDetails ";
        using (var connection = _context.CreateConnection())
        {
            int avgRoomCount = connection.QueryFirstOrDefault<int>(query);
            return avgRoomCount;
        }
    }

    public int CategoryCount()
    {
        string query = "SELECT Count(*) From Categories ";
        using (var connection = _context.CreateConnection())
        {
            int categoryCount = connection.QueryFirstOrDefault<int>(query);
            return categoryCount;
        }
    }

    public string CategoryNameByMaxProductCount()
    {
        string query = "SELECT Top(1) CategoryName ,Count(*) FROM Products p inner join Categories c on p.CategoryId = c.CategoryId Group By CategoryName  ORDER By Count(*) Desc ";
        using (var connection = _context.CreateConnection())
        {
            string categoryNameByMaxProductCount = connection.QueryFirstOrDefault<string>(query);
            return categoryNameByMaxProductCount;
        }
    }

    public string CityNameByMaxProductCount()
    {
        string query = "SELECT Top(1) City ,Count(*) FROM Products Group By City  ORDER By Count(*) Desc ";
        using (var connection = _context.CreateConnection())
        {
            string cityNameByMaxProductCount = connection.QueryFirstOrDefault<string>(query);
            return cityNameByMaxProductCount;
        }
    }

    public int DifferentCityCount()
    {
        string query = "SELECT COUNT(DISTINCT (City))  from Products ";
        using (var connection = _context.CreateConnection())
        {
            int differentCityCount = connection.QueryFirstOrDefault<int>(query);
            return differentCityCount;
        }
    }

    public string EmployeeNameByMaxProductCount()
    {
        string query = "SELECT Top(1) e.Name  ,Count(*) FROM Products p inner join Employees e on p.EmployeeId = e.EmployeeId  Group By Name  ORDER By Count(*) Desc ";
        using (var connection = _context.CreateConnection())
        {
            string employeeNameByMaxProductCount = connection.QueryFirstOrDefault<string>(query);
            return employeeNameByMaxProductCount;
        };
    }

    public decimal LastProductPrice()
    {
        string query = "SELECT Price  FROM Products order by ProductId desc ";
        using (var connection = _context.CreateConnection())
        {
            decimal lastProductPrice = connection.QueryFirstOrDefault<decimal>(query);
            return lastProductPrice;
        }
    }

    public string NewestBuildingYear()
    {
        string query = "SELECT BuildYear  FROM ProductDetails order by BuildYear DESC ";
        using (var connection = _context.CreateConnection())
        {
            string newestBuildingYear = connection.QueryFirstOrDefault<string>(query);
            return newestBuildingYear;
        }
    }

    public string OldestBuildingYear()
    {
        string query = "SELECT BuildYear  FROM ProductDetails order by BuildYear ";
        using (var connection = _context.CreateConnection())
        {
            string oldestBuildingYear = connection.QueryFirstOrDefault<string>(query);
            return oldestBuildingYear;
        }
    }

    public int PassiveCategoryCount()
    {
        string query = "SELECT Count(Status) FROM Categories Where Status = 0 ";
        using (var connection = _context.CreateConnection())
        {
            int passiveCategoryCount = connection.QueryFirstOrDefault<int>(query);
            return passiveCategoryCount;
        }
    }

    public int ProductCount()
    {
        string query = "SELECT Count(*) FROM Products ";
        using (var connection = _context.CreateConnection())
        {
            int productCount = connection.QueryFirstOrDefault<int>(query);
            return productCount;
        }
    }
}
