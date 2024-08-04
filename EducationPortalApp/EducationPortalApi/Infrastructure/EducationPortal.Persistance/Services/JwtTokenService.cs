using EducationPortal.Application;
using EducationPortal.Application.Services;
using EducationPortal.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Persistance.Services
{
    public class JwtTokenService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IConfiguration _configuration;


        public JwtTokenService(JwtSettings jwtSettings, IConfiguration configuration = null)
        {
            _jwtSettings = jwtSettings;
            _configuration = configuration;
        }

        public string GenerateToken(String userId)
        {
            var jwtSettings = _configuration.GetSection("Jwt").Get<JwtSettings>();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtSettings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new []
                {
                new Claim(ClaimTypes.NameIdentifier,userId)
                
                }),
                Issuer = jwtSettings.Issuer,
                Audience = jwtSettings.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
