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
    public class SetorController : ControllerBase
    {
        private SetorRepository _SetorRepository { get; set; }

        public SetorController()
        {
            _SetorRepository = new SetorRepository();
        }

        /// <summary>
        /// Lista todos os Setores
        /// </summary>
        /// <returns>Uma lista com todos os Setores</returns>
        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                // Retorna um status code Ok(200) e uma lista de Setores
                return Ok(_SetorRepository.GetAll());
            }
            catch (Exception erro)
            {
                // Retorna um status code BadRequest(400)
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Cadastra um novo Setor
        /// </summary>
        /// <param name="up">Setor que será cadastrado</param>
        /// <returns>Um status code Created(201)</returns>
        [HttpPost]
        //[Authorize(Roles = "1")]  
        public IActionResult Cadastrar(SetorViewModel up)
        {
            try
            {
                _SetorRepository.Save(up);

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
        /// Deleta um Setor existente
        /// </summary>
        /// <param name="id">Id do Setor que será deletado</param>
        /// <returns>Um status code NoContent(204)</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult Deletar(int id)
        {
            try
            {
                // Cadastra um novo Setor
                _SetorRepository.Delete(id);

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
