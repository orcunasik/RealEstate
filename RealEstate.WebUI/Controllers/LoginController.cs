using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using RealEstate.WebUI.Configurations;
using RealEstate.WebUI.Dtos.LoginDtos;
using RealEstate.WebUI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace RealEstate.WebUI.Controllers;
public class LoginController : Controller
{

    private readonly IHttpClientFactory _httpClient;
    private readonly IDomainService _domainService;
    public LoginController(IHttpClientFactory httpClient, IDomainService domainService)
    {
        _httpClient = httpClient;
        _domainService = domainService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(CreateLoginDto createLoginDto)
    {
        HttpClient client = _httpClient.CreateClient();
        var content = new StringContent(JsonSerializer.Serialize(createLoginDto), Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PostAsync(_domainService.Domain() + "api/Login", content);
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var tokenModel = JsonSerializer.Deserialize<JwtResponseViewModel>(jsonData, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            if (tokenModel != null)
            {
                JwtSecurityTokenHandler handler = new();
                JwtSecurityToken token = handler.ReadJwtToken(tokenModel.Token);
                var claims = token.Claims.ToList();
                if (tokenModel.Token != null)
                {
                    claims.Add(new Claim("realestatetoken", tokenModel.Token));
                    var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                    var authProps = new AuthenticationProperties
                    {
                        ExpiresUtc = tokenModel.ExpireDate,
                        IsPersistent = true
                    };
                    await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);
                    return RedirectToAction("Index","Employee");
                }
            }
        }
        return View();
    }
}