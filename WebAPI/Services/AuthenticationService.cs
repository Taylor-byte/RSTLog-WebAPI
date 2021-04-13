using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Configurations;
using WebAPI.Models;
using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace WebAPI.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly JwtConfiguration _jwtSettings;
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;
        private readonly UserManager<ApiUser> _userManager;

        public AuthenticationService(IOptions<JwtConfiguration> jwtSettings,
            UserManager<ApiUser> userManager)
        {
            _jwtSettings = jwtSettings.Value;
            _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            _userManager = userManager;
        }

        public async Task<string> GetToken(ApiUser user)
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims(user);
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            return _jwtSecurityTokenHandler.WriteToken(tokenOptions);
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_jwtSettings.SecurityKey);
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<IEnumerable<Claim>> GetClaims(ApiUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email)
            };

            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions
            (SigningCredentials signingCredentials, IEnumerable<Claim> claims)
        {
            var tokenOptions = new JwtSecurityToken(
                issuer: _jwtSettings.ValidIssuer,
                audience: _jwtSettings.ValidAudience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtSettings.ExpiryInMinutes)),
                signingCredentials: signingCredentials);

            return tokenOptions;
        }

       

        
    }
}
