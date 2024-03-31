using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StartupOne.Api.AspNet.Models;
using StartupOne.Api.AspNet.Repository.Context;
using StartupOne.Api.AspNet.Repository;

namespace StartupOne.Api.AspNet.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioRepository usuarioRepository;

        public UsuarioController(DataBaseContext context)
        {
            usuarioRepository = new UsuarioRepository(context);
        }

        [HttpGet]
        public ActionResult<List<UsuarioModel>> Get()
        {
            try
            {
                var lista = usuarioRepository.Listar();

                if (lista != null)
                {
                    return Ok(lista);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<UsuarioModel> Get([FromRoute] string id)
        {
            try
            {
                var usuarioModel = usuarioRepository.Buscar(id);

                if (usuarioModel != null)
                {
                    return Ok(usuarioModel);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public ActionResult<UsuarioModel> Post([FromBody] UsuarioModel usuarioModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                usuarioRepository.Inserir(usuarioModel);
                var location = new Uri(Request.GetEncodedUrl() + "/" + usuarioModel.CpfUsuario);
                return Created(location, usuarioModel);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível o Representante. Detalhes: {error.Message}" });
            }
        }

        [HttpPut("{id}")]
        public ActionResult<UsuarioModel> Put([FromRoute] string id, [FromBody] UsuarioModel usuarioModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (usuarioModel.CpfUsuario != id)
            {
                return NotFound();
            }

            try
            {
                usuarioRepository.Alterar(usuarioModel);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível alterar Representante. Detalhes: {error.Message}" });
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<UsuarioModel> Delete([FromRoute] string id)
        {
            try
            {
                usuarioRepository.Excluir(id);
                // Retorno Sucesso.
                // Efetuou a exclusão, porém sem necessidade de informar os dados.
                return NoContent();
            }
            catch (DbUpdateConcurrencyException e)
            {
                return BadRequest("ID não encontrado.");
            }
            catch (Exception e)
            {
                return BadRequest(e.StackTrace);
            }
        }
    }
}
