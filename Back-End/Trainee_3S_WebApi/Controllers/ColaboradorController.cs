using Microsoft.AspNetCore.Authorization;
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
    public class ColaboradorController : ControllerBase
    {
        private ColaboradorRepository _ColaboradorRepository { get; set; }

        public ColaboradorController()
        {
            _ColaboradorRepository = new ColaboradorRepository();
        }

        /// <summary>
        /// Lista todos os Colaboradores
        /// </summary>
        /// <returns>Uma lista com todos os Colaboradores</returns>
        [HttpGet]
        [Authorize(Roles = "1")]
        public IActionResult ListarTodos()
        {
            try
            {
                // Retorna um status code Ok(200) e uma lista de Colaboradores
                return Ok(_ColaboradorRepository.GetAll());
            }
            catch (Exception erro)
            {
                // Retorna um status code BadRequest(400)
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Cadastra um novo Colaborador
        /// </summary>
        /// <param name="up">Colaborador que será cadastrado</param>
        /// <returns>Um status code Created(201)</returns>
        [HttpPost]
        //[Authorize(Roles = "1")]  
        public IActionResult Cadastrar(ColaboradorViewModel up)
        {
            try
            {
                _ColaboradorRepository.Save(up);

                // Retorna um status code Created(201)
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                // Retorna um status code BadRequest(400)
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Deleta um Colaborador existente
        /// </summary>
        /// <param name="id">Id do Colaborador que será deletado</param>
        /// <returns>Um status code NoContent(204)</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult Deletar(int id)
        {
            try
            {
                // Cadastra um novo Colaborador
                _ColaboradorRepository.Delete(id);

                // Retorna um status code NoContent(204)
                return StatusCode(204);
            }
            catch (Exception erro)
            {
                // Retorna um status code BadRequest(400)
                return BadRequest(erro);
            }
        }

    }
}
