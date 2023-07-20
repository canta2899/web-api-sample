using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace WebApiExample.Services;

public class JwtService
{
   public string GetTokenFromClaims(Claim[] claims)
   {
        var tokenHandler = new JwtSecurityTokenHandler();
        
        var issueTime = DateTime.UtcNow;    

        var tokenDescriptor = new SecurityTokenDescriptor
        {
          Subject = new ClaimsIdentity(claims),
          IssuedAt = issueTime,
          Expires = issueTime.AddSeconds(Shared.DurationSeconds),
          SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Shared.Key), SecurityAlgorithms.HmacSha256Signature),
          Audience = Shared.Audience,
          Issuer = Shared.Issuer 
        };
        
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
   }
}