using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TravelAgency.DTOs.UserDTOs;

namespace TravelAgency.Helpers
{
    public static class JwtHelper
    {
        public static string GenerateToken(UserTokenDto user, IConfiguration configuration)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            Claim[] claims = new[]
            {
                new Claim(ClaimTypes.GroupSid, user.OrganizationId.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.GivenName, user.DisplayName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Sid, user.Id),
                new Claim(ClaimTypes.Role, user.Role ?? "USER"),
                new Claim(ClaimTypes.Name, user.FirstName ?? "/"),
                new Claim(ClaimTypes.Surname, user.LastName ?? "/"),
                new Claim(ClaimTypes.StreetAddress, user.Address ?? "/")
            };

            JwtSecurityToken token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(int.Parse(configuration["Jwt:ExpireTime"])),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static string GenerateRefreshToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }

        public static UserTokenDto GetCurrentUser(ClaimsPrincipal user)
        {
            return new UserTokenDto
            {
                OrganizationId = int.Parse(user.FindFirstValue(ClaimTypes.GroupSid)),
                Id = user.FindFirst(ClaimTypes.Sid)?.Value,
                Username = user.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                DisplayName = user.FindFirst(ClaimTypes.GivenName)?.Value,
                Email = user.FindFirst(ClaimTypes.Email)?.Value,
                Role = user.FindFirst(ClaimTypes.Role)?.Value,
                FirstName = user.FindFirst(ClaimTypes.Name)?.Value,
                LastName = user.FindFirst(ClaimTypes.Surname)?.Value,
                Address = user.FindFirst(ClaimTypes.StreetAddress)?.Value
            };
        }
    }
}
