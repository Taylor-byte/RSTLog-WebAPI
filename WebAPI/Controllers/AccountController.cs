using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.DTOs;
using WebAPI.Services;
using EmailService;
using Microsoft.AspNetCore.WebUtilities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly UserManager<ApiUser> _userManager;
        //private readonly SignInManager<ApiUser> _signInManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;
        private readonly IAuthManager _authManager;
        private readonly IAuthenticationService _authenticationService;
        private readonly IEmailSender _emailSender;

        public AccountController(UserManager<ApiUser> userManager,
            ILogger<AccountController> logger,
            IMapper mapper,
            IAuthManager authManager,
            IAuthenticationService authenticationService,
            IEmailSender emailSender)
        {
            _userManager = userManager;
           // _signInManager = signInManager;
            _logger = logger;
            _mapper = mapper;
            _authManager = authManager;
            _authenticationService = authenticationService;
            _emailSender = emailSender;
        }



        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDTO userForRegistrationDTO)
        {
            _logger.LogInformation($"Registration attempt for {userForRegistrationDTO.Email}");
            if (userForRegistrationDTO == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new ApiUser
            {
                UserName = userForRegistrationDTO.Email,
                Email = userForRegistrationDTO.Email
            };
                
                var result = await _userManager.CreateAsync(user, userForRegistrationDTO.Password);

                if (!result.Succeeded)
                {
                    //foreach (var error in result.Errors)
                    //{
                    //    ModelState.AddModelError(error.Code, error.Description);
                    //}
                    //return BadRequest(ModelState);

                    var errors = result.Errors.Select(e => e.Description);
                    return BadRequest(new ResponseDTO { Errors = errors });
                }

                await _userManager.AddToRoleAsync(user, "User");

                return StatusCode(201);
           
                //_logger.LogError(ex, $"Something went wrong in the {nameof(RegisterUser)}");
                //return Problem($"Something went wrong in the {nameof(RegisterUser)}", statusCode: 500);
            

        }



        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserForAuthenticationDTO userForAuthenticationDTO)
        {
            _logger.LogInformation($"Login attempt for {userForAuthenticationDTO.Email}");

            var user = await _userManager.FindByNameAsync(userForAuthenticationDTO.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user,
                userForAuthenticationDTO.Password))
            {
                return Unauthorized(new AuthResponseDTO
                {
                    ErrorMessage = "Invalid Authentication"
                });
            }

            var token = await _authenticationService.GetToken(user);

            user.RefreshToken = _authenticationService.GenerateRefreshToken();
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
            await _userManager.UpdateAsync(user);

            return Ok(new AuthResponseDTO {
                IsAuthSuccessful = true,
                Token = token,
                RefreshToken = user.RefreshToken
            });
        }

        [HttpPost]
        [Route("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(
        [FromBody] ForgotPasswordDTO forgotPasswordDTO)
        {
            //Return bad request not "email not found". Could be used to work out which emails exists in the database.
            var user = await _userManager.FindByEmailAsync(forgotPasswordDTO.Email);
            if (user == null)
                return BadRequest("Invalid Request");

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var param = new Dictionary<string, string>
            {
                { "token", token },
                { "email", forgotPasswordDTO.Email }
            };

            var callback = QueryHelpers.AddQueryString(forgotPasswordDTO.ClientURI, param);

            var message = new Message(new string[] { user.Email }, "Reset password token",
                callback, null);

            await _emailSender.SendEmailAsync(message);

            return Ok();
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(
            [FromBody] ResetPasswordDTO resetPasswordDTO)
        {
            var errorResponse = new ResetPasswordResponseDTO
            {
                Errors = new string[] { "Reset Password Failed" }
            };

            if (!ModelState.IsValid)
                return BadRequest(errorResponse);
            //finds the email of the users account
            var user = await _userManager.FindByEmailAsync(resetPasswordDTO.Email);
            if (user == null)
                return BadRequest(errorResponse);

            var resetPassResult = await _userManager.ResetPasswordAsync(user,
                resetPasswordDTO.Token, resetPasswordDTO.Password);

            if (!resetPassResult.Succeeded)
            {
                var errors = resetPassResult.Errors.Select(e => e.Description);
                return BadRequest(new ResetPasswordResponseDTO { Errors = errors });
            }

            await _userManager.SetLockoutEndDateAsync(user, null);

            return Ok(new ResetPasswordResponseDTO { IsResetPasswordSuccessful = true });
        }

    }

   

    //[HttpPost]
    //[Route("Login")]
    //public async Task<IActionResult> Login([FromBody] LoginUserDTO userDTO)
    //{
    //    _logger.LogInformation($"Login attempt for {userDTO.Email}");
    //    if (!ModelState.IsValid)
    //    {
    //        return BadRequest(ModelState);
    //    }
    //    try
    //    {
    //        if (!await _authManager.ValidateUser(userDTO))
    //        {
    //            return Unauthorized();
    //        }

    //        return Accepted(new { Token = await _authManager.CreateToken() });
    //    }
    //    catch (Exception ex)
    //    {
    //        _logger.LogError(ex, $"Something went wrong in the {nameof(Login)}");
    //        return Problem($"Something went wrong in the {nameof(Login)}", statusCode: 500);
    //    }

    //}

    //[HttpPost]
    //[Route("register")]
    //[ProducesResponseType(StatusCodes.Status202Accepted)]
    //[ProducesResponseType(StatusCodes.Status400BadRequest)]
    //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
    //public async Task<IActionResult> Register([FromBody] UserDTO userDTO)
    //{
    //    _logger.LogInformation($"Registration attempt for {userDTO.Email}");
    //    if (!ModelState.IsValid)
    //    {
    //        return BadRequest(ModelState);
    //    }
    //    try
    //    {
    //        var user = _mapper.Map<ApiUser>(userDTO);
    //        user.UserName = userDTO.Email;
    //        var result = await _userManager.CreateAsync(user, userDTO.Password);

    //        if(!result.Succeeded)
    //        {
    //            foreach (var error in result.Errors)
    //            {
    //                ModelState.AddModelError(error.Code, error.Description);
    //            }
    //            return BadRequest(ModelState);
    //        }

    //        await _userManager.AddToRolesAsync(user, userDTO.Roles);
    //        return Accepted();
    //    }
    //    catch (Exception ex)
    //    {
    //        _logger.LogError(ex, $"Something went wrong in the {nameof(Register)}");
    //        return Problem($"Something went wrong in the {nameof(Register)}", statusCode: 500);
    //    }

    //}
}
