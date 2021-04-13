using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IAuthenticationService
    {
       Task<string> GetToken(ApiUser user);
       string GenerateRefreshToken();
       ClaimsPrincipal GetPrincipalFromExpiredToken(string token);

    }
}
