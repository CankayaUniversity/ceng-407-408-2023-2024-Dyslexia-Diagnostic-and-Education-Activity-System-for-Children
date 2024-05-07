using DyslexiaAppMAUI.Shared.Dtos;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace DyslexiaApp.API.Services
{
    public class TokenService(IConfiguration configuration)
    {
        private readonly IConfiguration _configuration = configuration;

        public static TokenValidationParameters GetTokenValidationParameters(IConfiguration configuration) =>
            new()
            {

                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["Jwt:Issuer"],
                IssuerSigningKey = GetSecurityKey(configuration),


            };


        public string GenerateJwt(LoggedInUser user)
        {
            var securityKey = GetSecurityKey(_configuration);

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var issuer = _configuration["Jwt:Issuer"];
            var expireInMinutes = Convert.ToInt32(_configuration["Jwt:ExpireInMinute"]);

            Claim[] claims = [
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim (ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                ];
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: "*",
                claims: claims,
                expires: DateTime.Now.AddMinutes(expireInMinutes),
                signingCredentials: credentials);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;

        }

        private static SymmetricSecurityKey GetSecurityKey(IConfiguration configuration)
        {
            var secretKey = configuration["Jwt:SecretKey"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!));
            return securityKey;
        }

        public string GeneratePasswordResetToken(string userEmail)
        {
            // Token içeriğini hazırla: kullanıcının e-postası ve zaman damgası
            long time = DateTimeOffset.UtcNow.ToUnixTimeSeconds(); // Mevcut zamanı Unix zaman damgası olarak al
            string tokenData = $"{userEmail}-{time}";

            // SHA256 kullanarak tokenData'yı hash'le
            using var sha256 = SHA256.Create();
            byte[] hashedData = sha256.ComputeHash(Encoding.UTF8.GetBytes(tokenData));
            string token = Convert.ToBase64String(hashedData);

            // Token ve son kullanma zamanını geri döndür
            return token;
        }
    }
}