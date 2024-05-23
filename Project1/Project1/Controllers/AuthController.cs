using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Project1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpGet("LoginAdmin")]
        public IActionResult LoginAdmin()
        {
            var token = TokenService.GenerateToken("Admin");
            return Ok(new { Token = token });
        }

        [HttpGet("LoginUser")]
        public IActionResult LoginUser()
        {
            var token = TokenService.GenerateToken("User");
            return Ok(new { Token = token });
        }
    }

    public static class TokenService
    {
        private const string Secret = "QWREASDFZXCV!@$#1234UIPOHJKLBNM<FGHJ";

        public static string GenerateToken(string role)
        {
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Secret);
            var tokenDescriptor = new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Role, role)
            }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }

}
