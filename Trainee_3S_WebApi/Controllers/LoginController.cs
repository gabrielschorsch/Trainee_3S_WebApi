using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Trainee_3S_WebApi.Domains;
using Trainee_3S_WebApi.ViewModel;

namespace Trainee_3S_WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login(LoginViewModel data)
        {
            try
            {
                //fazer request
                Usuario usuarioBuscado = new Usuario();

                var claims = new[]
                {
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                new Claim(ClaimTypes.Role, usuarioBuscado.Tipo.Titulo)
            };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(""));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "ACCESS_S3.WebApi",
                    audience: "ACCESS_S3.WebApi",
                    claims: claims,
                    expires: DateTime.Now.AddDays(30),
                    signingCredentials: creds);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception e) {
                return BadRequest(new
                {
                    message = "Falha ao realizar login"
                });
            }
        }
    }
}
