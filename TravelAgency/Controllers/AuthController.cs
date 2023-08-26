using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using TravelAgency.Domain.Models;
using TravelAgency.DTOs.UserDTOs;
using TravelAgency.Helpers;
using TravelAgency.Mappers;
using TravelAgency.Services.Interfaces;

namespace TravelAgency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;
        public AuthController(IAuthService authService, IConfiguration configuration)
        {
            _authService = authService;
            _configuration = configuration;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserLoginResponseDto>> Login(UserLoginDto dto)
        {
            try
            {
                UserTokenDto user = await _authService.Login(dto);
                if (user == null)
                {
                    return BadRequest("Bad credentials");
                }

                string token = JwtHelper.GenerateToken(user, _configuration);
                string refreshToken = JwtHelper.GenerateRefreshToken(user, _configuration);
                await _authService.LogLastToken(user.Id, token);
                UserLoginResponseDto response = new UserLoginResponseDto
                {
                    Username = user.Username,
                    Email = user.Email,
                    DisplayName = user.DisplayName,
                    BankAccountNumber = user.BankAccountNumber,
                    Token = token,
                    RefreshToken = refreshToken
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult<UserLoginResponseDto>> RegisterUser(UserRegisterDto dto)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest();
                }
                await _authService.RegisterUser(dto);

                UserTokenDto user = await _authService.Login(new UserLoginDto { Username = dto.Username, Password = dto.Passowrd });
                if (user == null)
                {
                    return BadRequest("Bad credentials");
                }

                string token = JwtHelper.GenerateToken(user, _configuration);
                string refreshToken = JwtHelper.GenerateRefreshToken(user, _configuration);
                await _authService.LogLastToken(user.Id, token);
                UserLoginResponseDto response = new UserLoginResponseDto
                {
                    Username = user.Username,
                    Email = user.Email,
                    DisplayName = user.DisplayName,
                    BankAccountNumber = user.BankAccountNumber,
                    Token = token,
                    RefreshToken = refreshToken
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
