using Microsoft.AspNetCore.Mvc;
using StartupOne.Api.AspNet.Models;
using StartupOne.Api.AspNet.Repository;
using StartupOne.Api.AspNet.Repository.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.EntityFrameworkCore;
using System.DirectoryServices.ActiveDirectory;

namespace StartupOne.Api.AspNet.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestadorController : ControllerBase
    {
        private readonly PrestadorRepository prestadorRepository;

        public PrestadorController(DataBaseContext context)
        {
            prestadorRepository = new PrestadorRepository(context);
        }

        [HttpGet]
        public ActionResult<List<PrestadorModel>> Get()
        {
            try
            {
                var lista = prestadorRepository.Listar();

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
        public ActionResult<PrestadorModel> Get([FromRoute] string id)
        {
            try
            {
                var prestadorModel = prestadorRepository.Buscar(id);

                if (prestadorModel != null)
                {
                    return Ok(prestadorModel);
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
        public ActionResult<PrestadorModel> Post([FromBody] PrestadorModel prestadorModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                prestadorRepository.Inserir(prestadorModel);
                var location = new Uri(Request.GetEncodedUrl() + "/" + prestadorModel.CpfPrestadorId);
                return Created(location, prestadorModel);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível o Representante. Detalhes: {error.Message}" });
            }
        }

        [HttpPut("{id}")]
        public ActionResult<PrestadorModel> Put([FromRoute] string id, [FromBody] PrestadorModel prestadorModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (prestadorModel.CpfPrestadorId != id)
            {
                return NotFound();
            }

            try
            {
                prestadorRepository.Alterar(prestadorModel);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível alterar Representante. Detalhes: {error.Message}" });
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<PrestadorModel> Delete([FromRoute] string id)
        {
            try
            {
                prestadorRepository.Excluir(id);
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
