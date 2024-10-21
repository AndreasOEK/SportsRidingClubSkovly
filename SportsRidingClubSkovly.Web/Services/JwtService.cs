using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using SportsRidingClubSkovly.Web.Services.Interface;

namespace SportsRidingClubSkovly.Web.Services;

public class JwtService : IJwtService
{
    Guid IJwtService.GetUserId(string token)
    {
        var jwt = new JwtSecurityToken(token);
        return Guid.Parse(jwt.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Sub).Value);
    }

    string IJwtService.GetUserName(string token)
    {
        var jwt = new JwtSecurityToken(token);
        return jwt.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Name).Value;
    }

    string IJwtService.GetUserEmail(string token)
    {
        var jwt = new JwtSecurityToken(token);
        return jwt.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Email).Value;
    }
}