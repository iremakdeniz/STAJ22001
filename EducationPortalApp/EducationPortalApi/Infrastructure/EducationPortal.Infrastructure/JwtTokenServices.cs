using EducationPortal.Application;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Infrastructure
{
    public class JwtTokenServices
    {
        private readonly IConfiguration _configuration;

        public JwtTokenServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(string userId)
        {
            var jwtSettings = _configuration.GetSection("Jwt").Get<JwtSettings>();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtSettings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.NameIdentifier, userId),

            }),
                Expires = DateTime.UtcNow.AddDays(7),
                Issuer = jwtSettings.Issuer,
                Audience = jwtSettings.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
