using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RealEstate.Api.Tools;
public class JwtTokenGenerator
{
    public static TokenResponseViewModel GenerateToken(GetCheckAppUserViewModel model)
    {
        List<Claim> claims = new();
        if (!string.IsNullOrWhiteSpace(model.Role))
            claims.Add(new Claim(ClaimTypes.Role, model.Role));
        claims.Add(new Claim(ClaimTypes.NameIdentifier, model.Id.ToString()));

        if (!string.IsNullOrWhiteSpace(model.UserName))
            claims.Add(new Claim("UserName", model.UserName));

        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefault.Key));
        SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        DateTime expireDate = DateTime.UtcNow.AddDays(JwtTokenDefault.Expire);
        JwtSecurityToken token = new(issuer:JwtTokenDefault.ValidIssuer, audience:JwtTokenDefault.ValidAudience,claims:claims,notBefore:DateTime.UtcNow,expires:expireDate,signingCredentials:signingCredentials);
        JwtSecurityTokenHandler tokenHandler = new();
        return new TokenResponseViewModel(tokenHandler.WriteToken(token), expireDate);
    }
}