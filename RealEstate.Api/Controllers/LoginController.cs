using Dapper;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Api.Dtos.LoginDtos;
using RealEstate.Api.Models.DapperContext;
using RealEstate.Api.Tools;
using System.Data;

namespace RealEstate.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly BaseContext _context;

    public LoginController(BaseContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> SignIn(CreateLoginDto loginDto)
    {
        string query = "Select * From AppUser Where UserName=@userName and Password=@password";
        string queryForUserId = "Select UserId From AppUser Where UserName=@userName and Password=@password";
        DynamicParameters parameters = new();
        parameters.Add("@userName", loginDto.UserName);
        parameters.Add("@password", loginDto.Password);
        using (IDbConnection connection = _context.CreateConnection())
        {
            CreateLoginDto values = await connection.QueryFirstOrDefaultAsync<CreateLoginDto>(query, parameters);
            GetAppUserIdDto userIdDto = await connection.QueryFirstAsync<GetAppUserIdDto>(queryForUserId,parameters);
            if (values != null)
            {
                GetCheckAppUserViewModel model = new();
                model.Id = userIdDto.UserId;
                model.UserName = values.UserName;
                TokenResponseViewModel token = JwtTokenGenerator.GenerateToken(model);
                return Ok(token);
            }
            else
                return Ok("Başarısız!");
        }
    }
}