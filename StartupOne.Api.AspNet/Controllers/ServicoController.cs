using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StartupOne.Api.AspNet.Models;
using StartupOne.Api.AspNet.Repository.Context;
using StartupOne.Api.AspNet.Repository;
using Microsoft.AspNetCore.Http.Extensions;


namespace StartupOne.Api.AspNet.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicoController : ControllerBase
    {
        private readonly ServicoRepository servicoRepository;

        public ServicoController(DataBaseContext context)
        {
            servicoRepository = new ServicoRepository(context);
        }

        [HttpGet]
        public ActionResult<List<ServicoModel>> Get()
        {
            try
            {
                var lista = servicoRepository.Listar();

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
        public ActionResult<ServicoModel> Get([FromRoute] int id)
        {
            try
            {
                var servicoModel = servicoRepository.Buscar(id);

                if (servicoModel != null)
                {
                    return Ok(servicoModel);
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
        public ActionResult<ServicoModel> Post([FromBody] ServicoModel servicoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                servicoRepository.Inserir(servicoModel);
                var location = new Uri(Request.GetEncodedUrl() + "/" + servicoModel.Id);
                return Created(location, servicoModel);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível incluir o serviço. Detalhes: {error.Message}" });
            }
        }

        [HttpPut("{id}")]
        public ActionResult<ServicoModel> Put([FromRoute] int id, [FromBody] ServicoModel servicoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (servicoModel.Id != id)
            {
                return NotFound();
            }

            try
            {
                servicoRepository.Alterar(servicoModel);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível alterar Serviço. Detalhes: {error.Message}" });
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<ServicoModel> Delete([FromRoute] int id)
        {
            try
            {
                servicoRepository.Excluir(id);
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
