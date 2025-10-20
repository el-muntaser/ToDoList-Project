using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListBAL.jwt
{
    public class TokenService : ITokenService
    {
        private readonly JwtSetting _jwtSettings;

        public TokenService(JwtSetting jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }


        public string GenerateToken(string userId, string RoleName, string firstName)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SigningKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim("userId", userId),
            new Claim(ClaimTypes.Role, RoleName),
            new Claim(ClaimTypes.Name, firstName),
           
        };

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(2),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
