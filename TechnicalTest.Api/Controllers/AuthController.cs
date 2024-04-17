using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TechnicalTest.Api.Models;
using TechnicalTest.Business.Interfaces;
using TechnicalTest.Utilities.Configs;

namespace TechnicalTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAppConfig _config;
        private readonly IEmployeeBusiness _employeeBusiness;        

        public AuthController(IAppConfig config, IEmployeeBusiness employeeBusiness)
        {
            _employeeBusiness = employeeBusiness;
            _config = config;
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginModel employee)
        {
            var employeeLogin = await _employeeBusiness.Get(employee.Email);

            if (BCrypt.Net.BCrypt.Verify(employee.Password, employeeLogin.Password))
            {
                var keyBytes = Encoding.UTF8.GetBytes(_config.SecretKey);
                var claims = new ClaimsIdentity();
                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, employee.Email));
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    SigningCredentials = new SigningCredentials
                    (
                        new SymmetricSecurityKey(keyBytes),
                        SecurityAlgorithms.HmacSha256Signature
                    )
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);                

                return Ok(new { token = tokenHandler.WriteToken(tokenConfig) });
            }
            else
            {
                return Unauthorized();
            }

        }
    }
}