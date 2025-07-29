using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ToDoListAPI.Domain.Entities;

namespace ToDoListAPI.Application.Utils
{
    public class JwtUtils
    {
        private readonly string _secretKey;
        private readonly IConfiguration _configuration;

        public JwtUtils(IConfiguration configuration)
        {
            _configuration = configuration;
            _secretKey = _configuration.GetSection("JwtSettings:Key").Value!.ToString();
        }

        public Token GenerateToken(int userId)
        {
            var key = Encoding.ASCII.GetBytes(_secretKey);
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    [
                        new Claim("id", userId.ToString())
                    ]),

                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            string tokenString = tokenHandler.WriteToken(token);

            return new Token(userId, tokenString);
        }

        public bool ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                }, out SecurityToken validatedToken);

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
