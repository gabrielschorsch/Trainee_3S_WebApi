using Microsoft.AspNetCore.Mvc;
using Trainee_3S_WebApi.Domains;
using Trainee_3S_WebApi.Repository;

namespace Trainee_3S_WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {

        private static UserRepository _userRepository;

        public UsuarioController () {
            if( _userRepository == null)
            {
                _userRepository = new UserRepository();
            }
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userRepository.GetUsers());
        }

    }
}
