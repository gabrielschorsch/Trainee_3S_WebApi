using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Trainee_3S_WebApi.Domains;
using Trainee_3S_WebApi.Repository;
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
                UserRepository usuarioRepository = new UserRepository();
                //fazer request
                Usuario usuarioBuscado = usuarioRepository.GetByEmailAndPassword(data.Email, data.Password);

                if(usuarioBuscado == null)
                {
                    return BadRequest(new
                    {
                        message="Falha ao encontrar usuario"
                    });
                }

                var claims = new[]
                {
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString())
            };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("access-3s-chave-autenticacao-enxecao-de-linguica-pra-preencher-bytes"));
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
