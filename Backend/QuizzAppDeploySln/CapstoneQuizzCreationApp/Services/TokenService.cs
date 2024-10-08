﻿using CapstoneQuizzCreationApp.Interfaces;
using CapstoneQuizzCreationApp.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CapstoneQuizzCreationApp.Services
{
    public class TokenService : ITokenService
    {
        private readonly string _secretKey;
        private readonly SymmetricSecurityKey _key;
        private readonly ILogger<TokenService> _logger; // Added for logging

        public TokenService(string token, ILogger<TokenService> logger) 
        {
            _secretKey = token;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            _logger = logger; // Assigned logger
        }

        /// <summary>
        /// Generates a JSON Web Token (JWT) for the given customer.
        /// </summary>
        /// <param name="customer">The customer for whom the token should be generated.</param>
        /// <returns>The generated JWT token.</returns>
        public async Task<string> GenerateToken(User user)
        {
            _logger.LogInformation("Generating token for customer {CustomerId}", user.UserId);

            string token = string.Empty;
            var claims = new List<Claim>()
            {
                new Claim("Id", user.UserId.ToString()),
                new Claim(ClaimTypes.Role, user.Role),
            };

            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
            var myToken = new JwtSecurityToken(null, null, claims, expires: DateTime.Now.AddDays(1), signingCredentials: credentials);
            token = new JwtSecurityTokenHandler().WriteToken(myToken);

            _logger.LogInformation("Token generated successfully for customer {CustomerId}", user.UserId);
            return token;
        }
        public (bool isValid, ClaimsPrincipal? claimsPrincipal) ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);

            try
            {
                var claimsPrincipal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                return (true, claimsPrincipal);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Token validation failed.");
                return (false, null);
            }
        }
    }
}
