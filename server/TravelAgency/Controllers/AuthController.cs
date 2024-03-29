﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
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
                string refreshToken = JwtHelper.GenerateRefreshToken();
                await _authService.SaveToken(user.Id, refreshToken);
                UserLoginResponseDto response = user.ToLoginResponse(token, refreshToken);
                string requestUrl = Request.GetDisplayUrl();
                response.ImageUrl = $"{requestUrl.Substring(0, requestUrl.Length - 15)}{response.ImageUrl}";
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
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                await _authService.RegisterUser(dto);

                UserTokenDto user = await _authService.Login(new UserLoginDto { Username = dto.Username, Password = dto.Password });
                if (user == null)
                {
                    return BadRequest("Bad credentials");
                }

                string token = JwtHelper.GenerateToken(user, _configuration);
                string refreshToken = JwtHelper.GenerateRefreshToken();
                await _authService.SaveToken(user.Id, refreshToken);
                UserLoginResponseDto response = user.ToLoginResponse(token, refreshToken);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("add")]
        [Authorize]
        public async Task<IActionResult> RegisterPartner(UserPartnerRegisterDto dto)
        {
            try
            {
                UserTokenDto user = JwtHelper.GetCurrentUser(User);
                await _authService.RegisterPartner(dto, user.Id);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("refresh-token")]
        [AllowAnonymous]
        public async Task<ActionResult<UserLoginResponseDto>> RefreshToken(UserRefreshDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                string newRefreshToken = JwtHelper.GenerateRefreshToken();
                UserTokenDto user = await _authService.CheckLastToken(dto.Username, dto.RefreshToken, newRefreshToken);
                if (user == null)
                {
                    return Unauthorized();
                }
                string token = JwtHelper.GenerateToken(user, _configuration);
                UserLoginResponseDto response = user.ToLoginResponse(token, newRefreshToken);
                string requestUrl = Request.GetDisplayUrl();
                response.ImageUrl = $"{requestUrl.Substring(0, requestUrl.Length - 23)}{response.ImageUrl}";
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
