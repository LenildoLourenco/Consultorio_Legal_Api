using System.Collections.Generic;
using System.Threading.Tasks;
using CL.Core.Shared.ModelViews.Erro;
using CL.Core.Shared.ModelViews.Medico;
using CL.Manager.Interfaces.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CL.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosController : ControllerBase
    {
        private readonly IMedicoManager _manager;

        public MedicosController(IMedicoManager manager)
        {
            this._manager = manager;
        }

        /// <summary>
        /// Retorna todos os médicos cadastrados na base de dados
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MedicoView>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _manager.GetMedicosAsync());
        }

        /// <summary>
        /// Retorna um médico consultado pelo Id
        /// </summary>
        /// <param name="id" example="123"></param>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(MedicoView), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _manager.GetMedicoAsync(id)); ;
        }

        /// <summary>
        /// Insere um novo médico
        /// </summary>
        /// <param name="medico"></param>
        [HttpPost]
        [ProducesResponseType(typeof(MedicoView), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(NovoMedico medico)
        {
            var medicoInserido = await _manager.InsertMedicoAsync(medico);
            return CreatedAtAction(nameof(Get), new { id = medicoInserido.Id }, medicoInserido);
        }

        /// <summary>
        /// Altera um médico
        /// </summary>
        [HttpPut]
        [ProducesResponseType(typeof(MedicoView), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(AlteraMedico medico)
        {
            var medicoAtualizado = await _manager.UpdateMedicoAsync(medico);
            if (medicoAtualizado == null)
            {
                return NotFound();
            }
            return Ok(medicoAtualizado);
        }

        /// <summary>
        /// Exclui um médico
        /// </summary>
        /// <param name="id" example="123"></param>
        /// <remarks>Ao excluir um Médico, o mesmo será removido permanentemente da base de dados</remarks>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _manager.DeleteMedicoAsync(id);
            return NoContent();
        }
    }
}
