using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTOs;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {

        private readonly UserManager<ApiUser> _usermanager;
        private readonly IAuthenticationService _authenticationService;

        public TokenController(UserManager<ApiUser> userManager,
            IAuthenticationService authenticationService)
        {
            _usermanager = userManager;
            _authenticationService = authenticationService;
        }

        public async Task<IActionResult> Refresh(
            [FromBody] RefreshTokenDTO tokenDTO)
        {
            if (tokenDTO == null)
                return BadRequest(new AuthResponseDTO
                {
                    IsAuthSuccessful = false,
                    ErrorMessage = "Invalid client request"
                });

            var principal = _authenticationService.GetPrincipalFromExpiredToken(tokenDTO.Token);
            var username = principal.Identity.Name;

            var user = await _usermanager.FindByNameAsync(username);
            if (user == null || user.RefreshToken != tokenDTO.RefreshToken ||
                user.RefreshTokenExpiryTime <= DateTime.Now)
                return BadRequest(new AuthResponseDTO
                {
                    IsAuthSuccessful = false,
                    ErrorMessage = "Invalid client request"
                });

            var token = await _authenticationService.GetToken(user);
            user.RefreshToken = _authenticationService.GenerateRefreshToken();

            await _usermanager.UpdateAsync(user);

            return Ok(new AuthResponseDTO
            {
                Token = token,
                RefreshToken = user.RefreshToken,
                IsAuthSuccessful = true
            });

        }
    }
}
