using ItMaraphoneExample.API.Data.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ItMaraphoneExample.API.Infrastucture
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        public SymmetricSecurityKey _key;

        public JwtTokenGenerator(IConfiguration configuration)
        {
            var key = configuration.GetValue<string>("TokenKey");
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        }

        public string CreateToken(ApplicationUser user)
        {
            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescription);

            return tokenHandler.WriteToken(token);
        }
    }
}
