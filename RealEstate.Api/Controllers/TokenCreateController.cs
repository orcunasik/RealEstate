using Microsoft.AspNetCore.Mvc;
using RealEstate.Api.Tools;

namespace RealEstate.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TokenCreateController : ControllerBase
{
    [HttpPost]
    public IActionResult CreateToken(GetCheckAppUserViewModel model)
    {
        TokenResponseViewModel values = JwtTokenGenerator.GenerateToken(model);
        return Ok(values);
    }
}